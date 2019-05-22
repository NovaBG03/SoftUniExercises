 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            FieldInfo[] fields = new FieldInfo[0];
            Type classType = typeof(HarvestingFields);

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "HARVEST":
                        return;
                    case "private":
                        fields = classType
                            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                            .Where(f => f
                                .Attributes
                                .HasFlag(FieldAttributes.Private))
                            .ToArray();
                        break;
                    case "protected":
                        fields = classType
                            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                            .Where(f => f
                                .Attributes
                                .HasFlag(FieldAttributes.Family))
                            .ToArray();
                        break;
                    case "public":
                        fields = classType.GetFields();
                        break;
                    case "all":
                        fields = classType
                            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                        break;
                    default:
                        continue;
                }

                foreach (var field in fields)
                {
                    string fieldModifier = field
                        .Attributes
                        .ToString()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .ToLower();

                    if (fieldModifier == FieldAttributes.Family.ToString().ToLower())
                    {
                        fieldModifier = "protected";
                    }

                    string fieldType = field.FieldType.Name;
                    string fieldName = field.Name;

                    Console.WriteLine($"{fieldModifier} {fieldType} {fieldName}");
                }
            }
        }
    }
}
