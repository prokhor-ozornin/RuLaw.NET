﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawsSearchResult"/>.</para>
  /// </summary>
  public sealed class LawsSearchResultTests : UnitTestsBase<LawsSearchResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new LawsSearchResult(), new { count = 0, laws = new object[] {}, page = 0 });
      TestJson(
        new LawsSearchResult
        {
          Count = 2,
          Page = 3,
          LawsOriginal = new List<Law> { new Law { Id = 1 }, },
          Wording = "wording"
        },
        new { count = 2, laws = new object[] { new { id = 1, committees = new { profile = new object[] {}, soexecutor = new object[] {} }, introductionDate = DateTime.MinValue, subject = new { departments = new object[] {}, deputies = new object[] {} } } }, page = 3, wording = "wording" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new LawsSearchResult(), "result", new { count = 0, page = 0 });
      TestXml(
        new LawsSearchResult
        {
          Count = 2,
          Page = 3,
          LawsOriginal = new List<Law> { new Law { Id = 1 }, },
          Wording = "wording"
        },
        "result",
        new { count = 2, page = 3, wording = "wording" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawsSearchResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new LawsSearchResult();
      Assert.Equal(0, result.Count);
      Assert.Empty(result.LawsOriginal);
      Assert.Empty(result.Laws);
      Assert.Equal(0, result.Page);
      Assert.Null(result.Wording);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new LawsSearchResult { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Laws_Property()
    {
      var result = new LawsSearchResult();
      var law = new Law();

      result.LawsOriginal.Add(law);
      Assert.True(ReferenceEquals(result.LawsOriginal.Single(), law));
      Assert.True(ReferenceEquals(result.Laws.Single(), law));

      result.LawsOriginal.Remove(law);
      Assert.Empty(result.LawsOriginal);
      Assert.Empty(result.Laws);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.Page"/> property.</para>
    /// </summary>
    [Fact]
    public void Page_Property()
    {
      Assert.Equal(1, new LawsSearchResult { Page = 1 }.Page);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.Wording"/> property.</para>
    /// </summary>
    [Fact]
    public void Wording_Property()
    {
      Assert.Equal("wording", new LawsSearchResult { Wording = "wording" }.Wording);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.CompareTo(ILawsSearchResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Count", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("wording", new LawsSearchResult { Wording = "wording" }.ToString());
    }
  }
}