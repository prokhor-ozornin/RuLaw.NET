﻿using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DateTranscriptsResult"/>.</para>
  /// </summary>
  public sealed class DateTranscriptsResultTests : UnitTestsBase<DateTranscriptsResult>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new DateTranscriptsResult(), new { date = default(DateTime), meetings = new object[] {} });
      TestJson(
        new DateTranscriptsResult
        {
          Date = DateTime.MinValue,
          MeetingsOriginal = new List<DateTranscriptMeeting> { new DateTranscriptMeeting() }
        },
        new { date = DateTime.MinValue, meetings = new object[] { new { date = DateTime.MinValue, lines = new object[] {}, number = 0, votes = new object[] {} } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new DateTranscriptsResult(), "result", new { date = default(DateTime).ISO8601()  });
      TestXml(
        new DateTranscriptsResult
        {
          Date = DateTime.MinValue,
          MeetingsOriginal = new List<DateTranscriptMeeting> { new DateTranscriptMeeting() }
        },
        "result",
        new { date = DateTime.MinValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DateTranscriptsResult()"/>
    [Fact]
    public void Constructors()
    {
      var result = new DateTranscriptsResult();
      Assert.Equal(default(DateTime), result.Date);
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new DateTranscriptsResult { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.Meetings"/> property.</para>
    /// </summary>
    [Fact]
    public void Meetings_Property()
    {
      var result = new DateTranscriptsResult();
      var meeting = new DateTranscriptMeeting();

      result.MeetingsOriginal.Add(meeting);
      Assert.True(ReferenceEquals(result.MeetingsOriginal.Single(), meeting));
      Assert.True(ReferenceEquals(result.Meetings.Single(), meeting));

      result.MeetingsOriginal.Remove(meeting);
      Assert.Empty(result.MeetingsOriginal);
      Assert.Empty(result.Meetings);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.CompareTo(IDateTranscriptsResult)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DateTranscriptsResult.Equals(IDateTranscriptsResult)"/></description></item>
    ///     <item><description><see cref="DateTranscriptsResult.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DateTranscriptsResult.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal(DateTime.MinValue.RuLawDate(), new DateTranscriptsResult { Date = DateTime.MinValue }.ToString());
    }
  }
}