// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.KeyVault
{
    /// <summary> A class representing collection of VaultKeyVersion and their operations over its parent. </summary>
    public partial class VaultKeyVersionCollection : ArmCollection, IEnumerable<VaultKeyVersion>, IAsyncEnumerable<VaultKeyVersion>
    {
        private readonly ClientDiagnostics _vaultKeyVersionKeysClientDiagnostics;
        private readonly KeysRestOperations _vaultKeyVersionKeysRestClient;

        /// <summary> Initializes a new instance of the <see cref="VaultKeyVersionCollection"/> class for mocking. </summary>
        protected VaultKeyVersionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VaultKeyVersionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VaultKeyVersionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vaultKeyVersionKeysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.KeyVault", VaultKeyVersion.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VaultKeyVersion.ResourceType, out string vaultKeyVersionKeysApiVersion);
            _vaultKeyVersionKeysRestClient = new KeysRestOperations(_vaultKeyVersionKeysClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, vaultKeyVersionKeysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VaultKey.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VaultKey.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified version of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public async virtual Task<Response<VaultKeyVersion>> GetAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Get");
            scope.Start();
            try
            {
                var response = await _vaultKeyVersionKeysRestClient.GetVersionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _vaultKeyVersionKeysClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VaultKeyVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified version of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<VaultKeyVersion> Get(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Get");
            scope.Start();
            try
            {
                var response = _vaultKeyVersionKeysRestClient.GetVersion(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken);
                if (response.Value == null)
                    throw _vaultKeyVersionKeysClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the versions of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions
        /// Operation Id: Keys_ListVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VaultKeyVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VaultKeyVersion> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VaultKeyVersion>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultKeyVersionKeysRestClient.ListVersionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VaultKeyVersion>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultKeyVersionKeysRestClient.ListVersionsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the versions of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions
        /// Operation Id: Keys_ListVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VaultKeyVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VaultKeyVersion> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VaultKeyVersion> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultKeyVersionKeysRestClient.ListVersions(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VaultKeyVersion> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultKeyVersionKeysRestClient.ListVersionsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(keyVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<bool> Exists(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(keyVersion, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public async virtual Task<Response<VaultKeyVersion>> GetIfExistsAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _vaultKeyVersionKeysRestClient.GetVersionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VaultKeyVersion>(null, response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<VaultKeyVersion> GetIfExists(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _vaultKeyVersionKeysRestClient.GetVersion(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VaultKeyVersion>(null, response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VaultKeyVersion> IEnumerable<VaultKeyVersion>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VaultKeyVersion> IAsyncEnumerable<VaultKeyVersion>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
