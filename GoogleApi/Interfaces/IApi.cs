using System.Threading;
using System.Threading.Tasks;

namespace GoogleApi.Interfaces;

/// <summary>
/// Base Api interface.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public interface IApi<in TRequest, TResponse>
{
    /// <summary>
    /// Query.
    /// </summary>
    /// <param name="request">The objwect of type <typeparamref name="TRequest"/></param>
    /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/> (optional).</param>
    /// <returns>The object of type <typeparamref name="TResponse"/>.</returns>
    TResponse Query(TRequest request, HttpEngineOptions httpEngineOptions = null);

    /// <summary>
    /// Query Async.
    /// </summary>
    /// <param name="request">The objwect of type <typeparamref name="TRequest"/></param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The object of type <typeparamref name="TResponse"/>.</returns>
    Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query Async.
    /// </summary>
    /// <param name="request">The objwect of type <typeparamref name="TRequest"/></param>
    /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/> (optional).</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The object of type <typeparamref name="TResponse"/>.</returns>
    Task<TResponse> QueryAsync(TRequest request, HttpEngineOptions httpEngineOptions, CancellationToken cancellationToken = default);
}