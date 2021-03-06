﻿namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Detailed deputy information.</para>
  /// </summary>
  [XmlType("deputy")]
  public sealed class DeputyInfo : IComparable<IDeputyInfo>, IEquatable<IDeputyInfo>, IDeputyInfo
  {
    /// <summary>
    ///   <para>Unique identifier of deputy.</para>
    /// </summary>
    [JsonProperty("id")]
    [XmlElement("id")]
    public long Id { get; set; }

    /// <summary>
    ///   <para>Whether deputy has authority and power at present moment.</para>
    /// </summary>
    [JsonProperty("isActual")]
    [XmlElement("isActual")]
    public bool Active { get; set; }

    /// <summary>
    ///   <para>Collection of deputy's activities in committees.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IDeputyActivity> Activities
    {
      get { return ActivitiesOriginal.Cast<IDeputyActivity>(); }
    }

    /// <summary>
    ///   <para>Collection of deputy's activities in committees.</para>
    /// </summary>
    [JsonProperty("activity")]
    [XmlElement("activity")]
    public List<DeputyActivity> ActivitiesOriginal { get; set; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime BirthDate { get; set; }

    /// <summary>
    ///   <para>Birth date of deputy.</para>
    /// </summary>
    [JsonProperty("birthdate")]
    [XmlElement("birthdate")]
    public string BirthDateOriginal
    {
      get { return BirthDate.ISO8601(); }
      set { BirthDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Scientific degrees of deputy.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<string> Degrees
    {
      get { return DegreesOriginal; }
    }

    /// <summary>
    ///   <para>Scientific degrees of deputy.</para>
    /// </summary>
    [JsonProperty("degrees")]
    [XmlElement("degree")]
    public List<string> DegreesOriginal { get; set; }

    /// <summary>
    ///   <para>Higher educations of deputy.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IEducation> Educations
    {
      get { return EducationsOriginal.Cast<IEducation>(); }
    }

    /// <summary>
    ///   <para>Higher educations of deputy.</para>
    /// </summary>
    [JsonProperty("educations")]
    [XmlElement("education")]
    public List<Education> EducationsOriginal { get; set; }

    /// <summary>
    ///   <para>Identifier of deputy's political faction.</para>
    /// </summary>
    [JsonProperty("factionId")]
    [XmlElement("factionId")]
    public long FactionId { get; set; }

    /// <summary>
    ///   <para>Name of deputy's political faction.</para>
    /// </summary>
    [JsonProperty("factionName")]
    [XmlElement("factionName")]
    public string FactionName { get; set; }

    /// <summary>
    ///   <para>Association of deputy's political faction with a region.</para>
    /// </summary>
    [JsonProperty("factionRegion")]
    [XmlElement("factionRegion")]
    public string FactionRegion { get; set; }

    /// <summary>
    ///   <para>Role of deputy's in his political faction.</para>
    /// </summary>
    [JsonProperty("factionRole")]
    [XmlElement("factionRole")]
    public string FactionRole { get; set; }

    /// <summary>
    ///   <para>First name of deputy.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string FirstName { get; set; }

    /// <summary>
    ///   <para>Last name of deputy.</para>
    /// </summary>
    [JsonProperty("family")]
    [XmlElement("family")]
    public string LastName { get; set; }

    /// <summary>
    ///   <para>Number of laws which have been initiated by the deputy.</para>
    /// </summary>
    [JsonProperty("lawcount")]
    [XmlElement("lawcount")]
    public int LawsCount { get; set; }

    /// <summary>
    ///   <para>Middle name of deputy.</para>
    /// </summary>
    [JsonProperty("patronymic")]
    [XmlElement("patronymic")]
    public string MiddleName { get; set; }

    /// <summary>
    ///   <para>Scientific ranks of deputy.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<string> Ranks
    {
      get { return RanksOriginal; }
    }

    /// <summary>
    ///   <para>Scientific ranks of deputy.</para>
    /// </summary>
    [JsonProperty("ranks")]
    [XmlElement("rank")]
    public List<string> RanksOriginal { get; set; }

    /// <summary>
    ///   <para>Association of deputy's with regions.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<string> Regions
    {
      get { return RegionsOriginal; }
    }

    /// <summary>
    ///   <para>Association of deputy's with regions.</para>
    /// </summary>
    [JsonProperty("regions")]
    [XmlElement("region")]
    public List<string> RegionsOriginal { get; set; }

    /// <summary>
    ///   <para>Number of deputy's public speaches.</para>
    /// </summary>
    [JsonProperty("speachCount")]
    [XmlElement("speachCount")]
    public int SpeachesCount { get; set; }

    /// <summary>
    ///   <para>URL link for transcripts of deputy's speaches.</para>
    /// </summary>
    [JsonProperty("transcriptLink")]
    [XmlElement("transcriptLink")]
    public string TranscriptLink { get; set; }

    /// <summary>
    ///   <para>URL link for deputy's votes.</para>
    /// </summary>
    [JsonProperty("voteLink")]
    [XmlElement("voteLink")]
    public string VoteLink { get; set; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime WorkStartDate { get; set; }

    /// <summary>
    ///   <para>Start date of deputy's authorities in last convocation.</para>
    /// </summary>
    [JsonProperty("credentialsStart")]
    [XmlElement("credentialsStart")]
    public string WorkStartDateOriginal
    {
      get { return WorkStartDate.ISO8601(); }
      set { WorkStartDate = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public DateTime? WorkEndDate { get; set; }

    /// <summary>
    ///   <para>End date of deputy's authorities in last convocation.</para>
    /// </summary>
    [JsonProperty("credentialsEnd")]
    [XmlElement("credentialsEnd")]
    public string WorkEndDateOriginal
    {
      get { return WorkEndDate != null ? WorkEndDate.Value.ISO8601() : null; }
      set { WorkEndDate = value.IsEmpty() ? (DateTime?)null : DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>Creates new deputy info.</para>
    /// </summary>
    public DeputyInfo()
    {
      ActivitiesOriginal = new List<DeputyActivity>();
      DegreesOriginal = new List<string>();
      EducationsOriginal = new List<Education>();
      RanksOriginal = new List<string>();
      RegionsOriginal = new List<string>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="IDeputyInfo"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IDeputyInfo"/> to compare with this instance.</param>
    public int CompareTo(IDeputyInfo other)
    {
      return this.FullName().CompareTo(other.FullName(), StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="IDeputyInfo"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IDeputyInfo other)
    {
      return this.Equality(other, deputy => deputy.Id);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as IDeputyInfo);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(deputy => deputy.Id);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="DeputyInfo"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="DeputyInfo"/>.</returns>
    public override string ToString()
    {
      return this.FullName();
    }
  }
}