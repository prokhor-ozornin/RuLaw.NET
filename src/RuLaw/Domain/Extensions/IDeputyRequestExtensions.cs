﻿namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDeputyRequest"/>.</para>
  /// </summary>
  /// <seealso cref="IDeputyRequest"/>
  public static class IDeputyRequestExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those containing specifid text fragment.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="requests">Source sequence of requests to filter.</param>
    /// <param name="text">Text fragment to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of requests that contain specified text.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="requests"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Answer<ENTITY>(this IEnumerable<ENTITY> requests, string text) where ENTITY : IDeputyRequest
    {
      Assertion.NotNull(requests);
      Assertion.NotEmpty(text);

      return requests.Where(request => request != null && request.Answer.ToLowerInvariant().Contains(text.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with control date in specified borders.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="requests">Source sequence of requests to filter.</param>
    /// <param name="from">Lower bound of control date period.</param>
    /// <param name="to">Upper bound of control date period.</param>
    /// <returns>Filtered sequence of requests.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> ControlDate<ENTITY>(this IEnumerable<ENTITY> requests, DateTime? from = null, DateTime? to = null) where ENTITY : IDeputyRequest
    {
      Assertion.NotNull(requests);

      if (from != null)
      {
        requests = requests.Where(request => request != null && request.ControlDate >= from.Value);
      }

      if (to != null)
      {
        requests = requests.Where(request => request != null && request.ControlDate <= to.Value);
      }

      return requests;
    }

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with a specified initiator.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="requests">Source sequence of requests to filter.</param>
    /// <param name="initiator">Full or partial name of initiator to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of requests with specified initiator.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="requests"/> or <paramref name="initiator"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="initiator"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Initiator<ENTITY>(this IEnumerable<ENTITY> requests, string initiator) where ENTITY : IDeputyRequest
    {
      Assertion.NotNull(requests);
      Assertion.NotEmpty(initiator);

      return requests.Where(request => request != null && request.Initiator.ToLowerInvariant().Contains(initiator.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with signing date in specified borders.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="requests">Source sequence of requests to filter.</param>
    /// <param name="from">Lower bound of signing date period.</param>
    /// <param name="to">Upper bound of signing date period.</param>
    /// <returns>Filtered sequence of requests.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> SignDate<ENTITY>(this IEnumerable<ENTITY> requests, DateTime? from = null, DateTime? to = null) where ENTITY : IDeputyRequest
    {
      Assertion.NotNull(requests);

      if (from != null)
      {
        requests = requests.Where(request => request != null && request.SignDate >= from.Value);
      }

      if (to != null)
      {
        requests = requests.Where(request => request != null && request.SignDate <= to.Value);
      }

      return requests;
    }
  }
}