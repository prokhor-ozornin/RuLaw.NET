﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="QuestionsSearchResult"/>.</para>
  /// </summary>
  public sealed class QuestionsSearchResultTests : UnitTestsBase<QuestionsSearchResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new QuestionsSearchResult(), new { page = 0, pageSize = 0, questions = new object[] { }, totalCount = 0 });
      TestJson(
        new QuestionsSearchResult
        {
          Count = 1,
          Page = 2,
          PageSize = 3,
          QuestionsOriginal = new List<Question> { new Question() }
        },
        new { page = 2, pageSize = 3, questions = new object[] { new { datez = DateTime.MinValue, kodvopr = 0, kodz = 0, nbegin = 0, nend = 0 } }, totalCount = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new QuestionsSearchResult(), "result", new { page = 0, pageSize = 0, totalCount = 0 });
      TestXml(
        new QuestionsSearchResult
        {
          Count = 1,
          Page = 2,
          PageSize = 3,
          QuestionsOriginal = new List<Question> { new Question() }
        },
        "result",
        new { page = 2, pageSize = 3, totalCount = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="QuestionsSearchResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new QuestionsSearchResult();
      Assert.Equal(0, result.Count);
      Assert.Equal(0, result.Page);
      Assert.Equal(0, result.PageSize);
      Assert.Empty(result.QuestionsOriginal);
      Assert.Empty(result.Questions);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsSearchResult.Count"/> property.</para>
    /// </summary>
    [Fact]
    public void Count_Property()
    {
      Assert.Equal(1, new QuestionsSearchResult { Count = 1 }.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsSearchResult.Page"/> property.</para>
    /// </summary>
    [Fact]
    public void Page_Property()
    {
      Assert.Equal(1, new QuestionsSearchResult { Page = 1 }.Page);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsSearchResult.PageSize"/> property.</para>
    /// </summary>
    [Fact]
    public void PageSize_Property()
    {
      Assert.Equal(1, new QuestionsSearchResult { PageSize = 1 }.PageSize);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="QuestionsSearchResult.Questions"/> property.</para>
    /// </summary>
    [Fact]
    public void Questions_Property()
    {
      var result = new QuestionsSearchResult();
      var question = new Question();

      result.QuestionsOriginal.Add(question);
      Assert.True(ReferenceEquals(result.QuestionsOriginal.Single(), question));
      Assert.True(ReferenceEquals(result.Questions.Single(), question));

      result.QuestionsOriginal.Remove(question);
      Assert.Empty(result.QuestionsOriginal);
      Assert.Empty(result.Questions);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawsSearchResult.CompareTo(ILawsSearchResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Count", 1, 2);
    }
  }
}