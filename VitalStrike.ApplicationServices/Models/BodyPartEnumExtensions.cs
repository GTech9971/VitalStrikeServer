using System.Reflection;
using System.Runtime.Serialization;

namespace VitalStrike.ApplicationServices.Models;

public static class BodyPartEnumExtensions
{

    public static Domains.Bodies.BodyPart? ConvertTo(this VitalStrike.Models.BodyPart model)
    {
        MemberInfo? memberInfo = typeof(VitalStrike.Models.BodyPart)
                            .GetMember(model.ToString())
                            .FirstOrDefault();

        if (memberInfo == null) { return null; }

        EnumMemberAttribute? attribute = memberInfo.GetCustomAttribute<EnumMemberAttribute>();
        if (attribute == null) { return null; }


        Domains.Bodies.BodyPart result;
        if (Enum.TryParse(attribute.Value, ignoreCase: true, out result)) { return result; }

        return null;
    }
}
