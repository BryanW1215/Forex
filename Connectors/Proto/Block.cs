// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: block.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Connectors.Proto {

  /// <summary>Holder for reflection information generated from block.proto</summary>
  public static partial class BlockReflection {

    #region Descriptor
    /// <summary>File descriptor for block.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BlockReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtibG9jay5wcm90byJNCgVCbG9jaxIMCgR0aW1lGAEgAygFEgwKBG9wZW4Y",
            "AiADKAISCwoDbG93GAMgAygCEgwKBGhpZ2gYBCADKAISDQoFY2xvc2UYBSAD",
            "KAJCE6oCEENvbm5lY3RvcnMuUHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Connectors.Proto.Block), global::Connectors.Proto.Block.Parser, new[]{ "Time", "Open", "Low", "High", "Close" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Block : pb::IMessage<Block> {
    private static readonly pb::MessageParser<Block> _parser = new pb::MessageParser<Block>(() => new Block());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Block> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Connectors.Proto.BlockReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block(Block other) : this() {
      time_ = other.time_.Clone();
      open_ = other.open_.Clone();
      low_ = other.low_.Clone();
      high_ = other.high_.Clone();
      close_ = other.close_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Block Clone() {
      return new Block(this);
    }

    /// <summary>Field number for the "time" field.</summary>
    public const int TimeFieldNumber = 1;
    private static readonly pb::FieldCodec<int> _repeated_time_codec
        = pb::FieldCodec.ForInt32(10);
    private readonly pbc::RepeatedField<int> time_ = new pbc::RepeatedField<int>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Time {
      get { return time_; }
    }

    /// <summary>Field number for the "open" field.</summary>
    public const int OpenFieldNumber = 2;
    private static readonly pb::FieldCodec<float> _repeated_open_codec
        = pb::FieldCodec.ForFloat(18);
    private readonly pbc::RepeatedField<float> open_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> Open {
      get { return open_; }
    }

    /// <summary>Field number for the "low" field.</summary>
    public const int LowFieldNumber = 3;
    private static readonly pb::FieldCodec<float> _repeated_low_codec
        = pb::FieldCodec.ForFloat(26);
    private readonly pbc::RepeatedField<float> low_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> Low {
      get { return low_; }
    }

    /// <summary>Field number for the "high" field.</summary>
    public const int HighFieldNumber = 4;
    private static readonly pb::FieldCodec<float> _repeated_high_codec
        = pb::FieldCodec.ForFloat(34);
    private readonly pbc::RepeatedField<float> high_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> High {
      get { return high_; }
    }

    /// <summary>Field number for the "close" field.</summary>
    public const int CloseFieldNumber = 5;
    private static readonly pb::FieldCodec<float> _repeated_close_codec
        = pb::FieldCodec.ForFloat(42);
    private readonly pbc::RepeatedField<float> close_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> Close {
      get { return close_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Block);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Block other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!time_.Equals(other.time_)) return false;
      if(!open_.Equals(other.open_)) return false;
      if(!low_.Equals(other.low_)) return false;
      if(!high_.Equals(other.high_)) return false;
      if(!close_.Equals(other.close_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= time_.GetHashCode();
      hash ^= open_.GetHashCode();
      hash ^= low_.GetHashCode();
      hash ^= high_.GetHashCode();
      hash ^= close_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      time_.WriteTo(output, _repeated_time_codec);
      open_.WriteTo(output, _repeated_open_codec);
      low_.WriteTo(output, _repeated_low_codec);
      high_.WriteTo(output, _repeated_high_codec);
      close_.WriteTo(output, _repeated_close_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += time_.CalculateSize(_repeated_time_codec);
      size += open_.CalculateSize(_repeated_open_codec);
      size += low_.CalculateSize(_repeated_low_codec);
      size += high_.CalculateSize(_repeated_high_codec);
      size += close_.CalculateSize(_repeated_close_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Block other) {
      if (other == null) {
        return;
      }
      time_.Add(other.time_);
      open_.Add(other.open_);
      low_.Add(other.low_);
      high_.Add(other.high_);
      close_.Add(other.close_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10:
          case 8: {
            time_.AddEntriesFrom(input, _repeated_time_codec);
            break;
          }
          case 18:
          case 21: {
            open_.AddEntriesFrom(input, _repeated_open_codec);
            break;
          }
          case 26:
          case 29: {
            low_.AddEntriesFrom(input, _repeated_low_codec);
            break;
          }
          case 34:
          case 37: {
            high_.AddEntriesFrom(input, _repeated_high_codec);
            break;
          }
          case 42:
          case 45: {
            close_.AddEntriesFrom(input, _repeated_close_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
