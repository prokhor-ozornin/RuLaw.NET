﻿using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TranscriptMeetingQuestionPart"/>.</para>
  /// </summary>
  public sealed class TranscriptMeetingQuestionPartTests : UnitTestsBase<TranscriptMeetingQuestionPart>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("EndLine", "Lines", "StartLine", "Text", "Votes");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new TranscriptMeetingQuestionPart(), new { endLine = 0, lines = new object[] {}, startLine = 0, votes = new object[] {} });
      this.TestJson(
        new TranscriptMeetingQuestionPart
        {
           EndLine = 2,
           Lines = new List<string> { "line" },
           StartLine = 1,
           Votes = new List<TranscriptVote> { new TranscriptVote { Date = DateTime.MinValue, Line = 3 } }
        },
        new { endLine = 2, lines = new object[] { "line" }, startLine = 1, votes = new object[] { new { date = DateTime.MinValue, line = 3 } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new TranscriptMeetingQuestionPart(), "part", new { endLine = 0, startLine = 0 });
      this.TestXml(
        new TranscriptMeetingQuestionPart
        {
          EndLine = 2,
          Lines = new List<string> { "line" },
          StartLine = 1,
          Votes = new List<TranscriptVote> { new TranscriptVote { Date = DateTime.MinValue, Line = 3 } }
        },
        "part",
        new { endLine = 2, startLine = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Education()"/>
    [Fact]
    public void Constructors()
    {
      var part = new TranscriptMeetingQuestionPart();
      Assert.Equal(0, part.EndLine);
      Assert.False(part.Lines.Any());
      Assert.Equal(0, part.StartLine);
      Assert.False(part.Votes.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.EndLine"/> property.</para>
    /// </summary>
    [Fact]
    public void EndLine_Property()
    {
      Assert.Equal(1, new TranscriptMeetingQuestionPart { EndLine = 1 }.EndLine);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Lines"/> property.</para>
    /// </summary>
    [Fact]
    public void Lines_Property()
    {
      var part = new TranscriptMeetingQuestionPart();

      part.Lines.Add("line");
      Assert.Equal("line", part.Lines.Single());

      part.Lines.Remove("line");
      Assert.False(part.Lines.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.StartLine"/> property.</para>
    /// </summary>
    [Fact]
    public void StartLine_Property()
    {
      Assert.Equal(1, new TranscriptMeetingQuestionPart { StartLine = 1 }.StartLine);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new TranscriptMeetingQuestionPart { Lines = new List<string> { "first", "second" } }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.Votes"/> property.</para>
    /// </summary>
    [Fact]
    public void Votes_Property()
    {
      var part = new TranscriptMeetingQuestionPart();

      var vote = new TranscriptVote();

      part.Votes.Add(vote);
      Assert.True(ReferenceEquals(vote, part.Votes.Single()));

      part.Votes.Remove(vote);
      Assert.False(part.Votes.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.CompareTo(TranscriptMeetingQuestionPart)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("StartLine", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TranscriptMeetingQuestionPart.Equals(TranscriptMeetingQuestionPart)"/></description></item>
    ///     <item><description><see cref="TranscriptMeetingQuestionPart.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("StartLine", 1, 2);
      this.TestEquality("EndLine", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("StartLine", 1, 2);
      this.TestHashCode("EndLine", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TranscriptMeetingQuestionPart.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("first{0}second".FormatSelf(Environment.NewLine), new TranscriptMeetingQuestionPart { Lines = new List<string> { "first", "second" } }.ToString());
    }
  }
}