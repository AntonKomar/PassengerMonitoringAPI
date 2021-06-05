using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace PassengersMonitoring.Data.Extension
{
    public static class SnakeToCamelCase
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var noLeadingUnderscore = Regex.Replace(input, @"^_", string.Empty);
            return Regex.Replace(noLeadingUnderscore, @"(?:(?<l>[a-z0-9])(?<r>[A-Z])|(?<l>[A-Z])(?<r>[A-Z][a-z0-9]))", "${l}_${r}").ToLower();
        }

        public static void ToSnakeCase(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.GetType().BaseType == typeof(object))
                {
                    entity.SetTableName(entity.GetTableName().ToSnakeCase());
                }

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }
    }
}
