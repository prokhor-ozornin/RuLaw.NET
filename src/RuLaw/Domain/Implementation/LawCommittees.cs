﻿namespace RuLaw
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Committees, associated with a law.</para>
  /// </summary>
  [XmlType("committees")]
  public sealed class LawCommittees : ILawCommittees
  {
    /// <summary>
    ///   <para>List of profile committees.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ICommittee> Profile
    {
      get { return ProfileOriginal.Cast<ICommittee>(); }
    }

    /// <summary>
    ///   <para>List of profile committees.</para>
    /// </summary>
    [JsonProperty("profile")]
    [XmlElement("profile")]
    public List<Committee> ProfileOriginal { get; set; }

    /// <summary>
    ///   <para>Responsible committee.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public ICommittee Responsible
    {
      get { return ResponsibleOriginal; }
    }

    /// <summary>
    ///   <para>Responsible committee.</para>
    /// </summary>
    [JsonProperty("responsible")]
    [XmlElement("responsible")]
    public Committee ResponsibleOriginal { get; set; }

    /// <summary>
    ///   <para>List of so-executor committees.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ICommittee> SoExecutor
    {
      get { return SoExecutorOriginal.Cast<ICommittee>(); }
    }

    /// <summary>
    ///   <para>List of so-executor committees.</para>
    /// </summary>
    [JsonProperty("soexecutor")]
    [XmlElement("soexecutor")]
    public List<Committee> SoExecutorOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new committees, associated with a law.</para>
    /// </summary>
    public LawCommittees()
    {
      ProfileOriginal = new List<Committee>();
      SoExecutorOriginal = new List<Committee>();
    }
  }
}