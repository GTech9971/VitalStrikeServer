namespace VitalStrike.Domains.Bodies;

using System.Runtime.Serialization;


public enum BodyPart
{
    [EnumMember(Value = "none")]
    None = 0,

    /// <summary>
    /// Enum FaceEnum for face
    /// </summary>
    [EnumMember(Value = "face")]
    FaceEnum = 1,

    /// <summary>
    /// Enum HairEnum for hair
    /// </summary>
    [EnumMember(Value = "hair")]
    HairEnum = 2,

    /// <summary>
    /// Enum UpperBodyEnum for upperBody
    /// </summary>
    [EnumMember(Value = "upperBody")]
    UpperBodyEnum = 3,

    /// <summary>
    /// Enum LeftArmEnum for leftArm
    /// </summary>
    [EnumMember(Value = "leftArm")]
    LeftArmEnum = 4,

    /// <summary>
    /// Enum RightArmEnum for rightArm
    /// </summary>
    [EnumMember(Value = "rightArm")]
    RightArmEnum = 5,

    /// <summary>
    /// Enum LeftHandEnum for leftHand
    /// </summary>
    [EnumMember(Value = "leftHand")]
    LeftHandEnum = 6,

    /// <summary>
    /// Enum RightHandEnum for rightHand
    /// </summary>
    [EnumMember(Value = "rightHand")]
    RightHandEnum = 7,

    /// <summary>
    /// Enum LeftLegEnum for leftLeg
    /// </summary>
    [EnumMember(Value = "leftLeg")]
    LeftLegEnum = 8,

    /// <summary>
    /// Enum RightLegEnum for rightLeg
    /// </summary>
    [EnumMember(Value = "rightLeg")]
    RightLegEnum = 9,

    /// <summary>
    /// Enum LeftFootEnum for leftFoot
    /// </summary>
    [EnumMember(Value = "leftFoot")]
    LeftFootEnum = 10,

    /// <summary>
    /// Enum RightFootEnum for rightFoot
    /// </summary>
    [EnumMember(Value = "rightFoot")]
    RightFootEnum = 11
}
