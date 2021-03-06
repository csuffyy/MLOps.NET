﻿using Azure;
using Azure.Storage.Blobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLOps.NET.Entities.Impl;
using MLOps.NET.Services;
using MLOps.NET.Storage;
using Moq;
using System;
using System.Threading.Tasks;

namespace MLOps.NET.Azure.Tests
{
    [TestClass]
    public class StorageAccountModelRepositoryTests
    {
        private Mock<BlobContainerClient> modelRepositoryClientMock;
        private Mock<BlobContainerClient> deploymentClientMock;
        private StorageAccountModelRepository sut;

        [TestInitialize]
        public void TestInitialize()
        {
            this.modelRepositoryClientMock = new Mock<BlobContainerClient>();
            this.deploymentClientMock = new Mock<BlobContainerClient>();

            sut = new StorageAccountModelRepository(modelRepositoryClientMock.Object, deploymentClientMock.Object, new ModelPathGenerator());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The model to be deployed does not exist")]
        public async Task DeployModel_NoSourceFileExist_ShouldThrowException()
        {
            var experiment = new Experiment("ExperimentName");

            var registeredModel = new RegisteredModel
            {
                RunId = Guid.NewGuid(),
                ExperimentId = experiment.ExperimentId
            };

            var deploymentTarget = new DeploymentTarget("Test");

            var blobClientMock = new Mock<BlobClient>();
            var responseMock = new Mock<Response<bool>>();

            blobClientMock.Setup(x => x.Exists(default)).Returns(responseMock.Object);

            this.modelRepositoryClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(blobClientMock.Object);

            // Act
            await sut.DeployModelAsync(deploymentTarget, registeredModel, experiment);
        }

        [TestMethod]
        public async Task DeployModel_GivenModelExists_ShouldCallCopyBlob()
        {
            var experiment = new Experiment("ExperimentName");

            var registeredModel = new RegisteredModel
            {
                RunId = Guid.NewGuid(),
                ExperimentId = experiment.ExperimentId
            };

            var deploymentTarget = new DeploymentTarget("Test");

            var blobClientMock = new Mock<BlobClient>();
            var deploymentClientMock = new Mock<BlobClient>();

            var responseMock = new Mock<Response<bool>>();
            responseMock.Setup(x => x.Value).Returns(true);

            var deploymentUri = new Uri("http://127.0.0.1:10000/devstoreaccount1/deployment/ExperimentName/Test/86cb3a36-0bc2-4710-b97e-0ba8a832c215.zip");

            var sourceUri = new Uri("http://127.0.0.1:10000/devstoreaccount1/model-repository/86cb3a36-0bc2-4710-b97e-0ba8a832c215.zip");

            blobClientMock.Setup(x => x.Exists(default)).Returns(responseMock.Object);
            blobClientMock.Setup(x => x.Uri).Returns(sourceUri);

            deploymentClientMock.Setup(x => x.Uri).Returns(deploymentUri);

            this.modelRepositoryClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(blobClientMock.Object);

            this.deploymentClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(deploymentClientMock.Object);

            // Act
            await sut.DeployModelAsync(deploymentTarget, registeredModel, experiment);

            //Assert
            deploymentClientMock.Verify(x => x.StartCopyFromUriAsync(sourceUri, null, null, null, null, null, default), Times.Once());
        }
    }
}
