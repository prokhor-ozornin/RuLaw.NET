﻿namespace RuLaw
{
  using System;
  using System.Globalization;
  using System.Collections.Generic;
  using Catharsis.Commons;

  internal sealed class VotesApiCaller : IVotesApiCaller
  {
    private readonly IApiCaller caller;

    public IApiCaller Api
    {
      get { return caller; }
    }

    public VotesApiCaller(IApiCaller caller)
    {
      Assertion.NotNull(caller);

      this.caller = caller;
    }

    public IVotesSearchResult Search(long? convocation = null, DateTime? from = null, DateTime? to = null, long? faction = null, long? deputy = null, string number = null, string keywords = null, int? page = null, PageSize? limit = null, VotesSorting? sorting = null)
    {
      return caller.Call<VotesSearchResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/voteSearch", caller.ApiToken), new Dictionary<string, object> { { "convocation", convocation }, { "from", from != null ? from.Value.RuLawDate() : null }, { "to", to != null ? to.Value.RuLawDate() : null }, { "faction", faction }, { "deputy", deputy }, { "number", number }, { "keywords", keywords }, { "page", page }, { "limit", (int?) limit }, { "sort", sorting != null ? sorting.Value.String() : null } }).Data;
    }
  }
}