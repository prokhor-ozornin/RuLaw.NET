﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ResolutionTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class ResolutionTranscriptsResultTests : UnitTestsBase<ResolutionTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new ResolutionTranscriptsResult(), new { meetings = new object[] { } });
      TestJson(
        new ResolutionTranscriptsResult
        {
          MeetingsOriginal = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Number = "number"
        },
        new { meetings = new object[] { new { date = DateTime.MinValue, maxNumber = 0, number = 0, questions = new object[] { } } }, number = "number" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(
        new ResolutionTranscriptsResult
        {
          MeetingsOriginal = new List<TranscriptMeeting> { new TranscriptMeeting() },
          Number = "number"
        },
        "result",
        new { number = "number" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ResolutionTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new ResolutionTranscriptsResult();
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
      Assert.Null(result.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var result = new ResolutionTranscriptsResult();
      Assert.Empty(result.Meetings);
      var meeting = new TranscriptMeeting();
      result.MeetingsOriginal.Add(meeting);
      Assert.True(ReferenceEquals(meeting, result.MeetingsOriginal.Single()));
      Assert.True(ReferenceEquals(meeting, result.Meetings.Single()));
      result.MeetingsOriginal.Remove(meeting);
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.Number"/> property.</para>
    /// </summary>
    [Fact]
    public void Number_Property()
    {
      Assert.Equal("number", new ResolutionTranscriptsResult { Number = "number" }.Number);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ResolutionTranscriptsResult.Equals(IResolutionTranscriptsResult)"/></description></item>
    ///     <item><description><see cref="ResolutionTranscriptsResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Number", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Number", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ResolutionTranscriptsResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("number", new ResolutionTranscriptsResult { Number = "number" }.ToString());
    }
  }
}