﻿using System;
using Xunit;

namespace RuLaw
{
    using System.Globalization;

    /// <summary>
  ///   <para>Tests set for class <see cref="RuLawXmlSerializer"/>.</para>
  /// </summary>
  public sealed class RuLawXmlSerializerTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RuLawXmlSerializer()"/>
    [Fact]
    public void Constructors()
    {
      var serializer = new RuLawXmlSerializer();
      Assert.Null(serializer.ContentType);
      Assert.Null(serializer.DateFormat);
      Assert.Null(serializer.Namespace);
      Assert.Null(serializer.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlSerializer.Serialize(object)"/> method.</para>
    /// </summary>
    [Fact]
    public void Serialize_Method()
    {
      object subject = "subject";
      Assert.Contains(string.Format(CultureInfo.InvariantCulture, "<result>{0}</result>", subject), new RuLawXmlSerializer().Serialize(subject));

      subject = true;
      Assert.Contains(string.Format(CultureInfo.InvariantCulture, "<result>{0}</result>", subject).ToLowerInvariant(), new RuLawXmlSerializer().Serialize(subject));

      subject = 15.5;
      Assert.Contains(string.Format(CultureInfo.InvariantCulture, "<result>{0}</result>", subject), new RuLawXmlSerializer().Serialize(subject));

      subject = Guid.NewGuid();
      Assert.Contains(string.Format(CultureInfo.InvariantCulture, "<result>{0}</result>", subject), new RuLawXmlSerializer().Serialize(subject));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlSerializer.RootElement"/> property.</para>
    /// </summary>
    [Fact]
    public void RootElement_Property()
    {
      Assert.Equal("rootElement", new RuLawXmlSerializer { RootElement = "rootElement" }.RootElement);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlSerializer.Namespace"/> property.</para>
    /// </summary>
    [Fact]
    public void Namespace_Property()
    {
      Assert.Equal("namespace", new RuLawXmlSerializer { Namespace = "namespace" }.Namespace);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlSerializer.DateFormat"/> property.</para>
    /// </summary>
    [Fact]
    public void DateFormat_Property()
    {
      Assert.Equal("dateFormat", new RuLawXmlSerializer { DateFormat = "dateFormat" }.DateFormat);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="RuLawXmlSerializer.ContentType"/> property.</para>
    /// </summary>
    [Fact]
    public void ContentType_Property()
    {
      Assert.Equal("contentType", new RuLawXmlSerializer { ContentType = "contentType" }.ContentType);
    }
  }
}