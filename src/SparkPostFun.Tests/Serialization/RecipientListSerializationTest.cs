using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class RecipientListSerializationTest
    {
        [Fact]
        public void CreateRecipientList_request_returns_expected_result()
        {
            var recipientList = new CreateRecipientList
            {
                Id = "unique_id_4_graduate_students_list",
                Name = "graduate_students",
                Description = "An email list of graduate students at UMBC",
                Attributes = new Dictionary<string, object>()
                {
                    { "internal_id", 112 },
                    { "list_group_id", 12321 }
                },
                Recipients = new List<Recipient>
                {
                    new()
                    {
                        Address = new Address { Email = "wilmaflin@yahoo.com", Name = "Wilma" },
                        Tags = new List<string> { "greeting", "prehistoric", "fred", "flintstone" },
                        Metadata = new Dictionary<string, object>
                        {
                            { "age", "24" },
                            { "place", "Bedrock" }
                        },
                        SubstitutionData = new Dictionary<string, object>
                        {
                            { "favorite_color", "SparkPost Orange" },
                            { "job", "Software Engineer" }
                        }
                    },
                    new()
                    {
                        Address = new Address { Email = "abc@flintstone.com", Name = "ABC" },
                        Tags = new List<string> { "driver", "flintstone" },
                        Metadata = new Dictionary<string, object>
                        {
                            { "age", "52" },
                            { "place", "MD" }
                        },
                        SubstitutionData = new Dictionary<string, object>
                        {
                            { "favorite_color", "Sky Blue" },
                            { "job", "Driver" }
                        }
                    },
                    new()
                    {
                        Address = new Address
                        {
                            Email = "fred.jones@flintstone.com", 
                            Name = "Grad Student Office", 
                            HeaderTo = "grad-student-office@flintstone.com"
                        },
                        Tags = new List<string> { "driver", "fred", "flintstone" },
                        Metadata = new Dictionary<string, object>
                        {
                            { "age", "33" },
                            { "place", "NY" }
                        },
                        SubstitutionData = new Dictionary<string, object>
                        {
                            { "favorite_color", "Bright Green" },
                            { "job", "Firefighter" }
                        }
                    }
                }
            };


            var json = JsonSerializer.Serialize(recipientList,
                JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            json.Should().Contain("email");
            json.Should().Contain("fred.jones@flintstone.com");
        }

        [Fact]
        public void CreateRecipientList_response_returns_expected_result()
        {
            var json = "{                                                   " +
                       "  \"results\": {                                    " +
                       "    \"total_rejected_recipients\": 0,               " +
                       "    \"total_accepted_recipients\": 3,               " +
                       "    \"id\": \"unique_id_4_graduate_students_list\", " +
                       "    \"name\": \"graduate_students\"                 " +
                       "  }                                                 " +
                       "}                                                   ";

            var response = JsonSerializer.Deserialize<CreateRecipientListResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("unique_id_4_graduate_students_list");
        }

        [Fact]
        public void RetrieveRecipientList_response_returns_expected_result()
        {
            var json = "{                                                                     " +
                       "  \"results\": {                                                      " +
                       "    \"id\": \"unique_id_4_graduate_students_list\",                   " +
                       "    \"name\": \"graduate_students\",                                  " +
                       "    \"description\": \"An email list of graduate students at UMBC\",  " +
                       "    \"attributes\": {                                                 " +
                       "      \"internal_id\": 112,                                           " +
                       "      \"list_group_id\": 12321                                        " +
                       "    },                                                                " +
                       "    \"total_accepted_recipients\": 3,                                 " +
                       "    \"recipients\": [                                                 " +
                       "      {                                                               " +
                       "        \"address\": {                                                " +
                       "          \"email\": \"wilmaflin@yahoo.com\",                         " +
                       "          \"name\": \"Wilma\"                                         " +
                       "        },                                                            " +
                       "        \"tags\": [                                                   " +
                       "          \"greeting\",                                               " +
                       "          \"prehistoric\",                                            " +
                       "          \"fred\",                                                   " +
                       "          \"flintstone\"                                              " +
                       "        ],                                                            " +
                       "        \"metadata\": {                                               " +
                       "          \"age\": \"24\",                                            " +
                       "          \"place\": \"Bedrock\"                                      " +
                       "        },                                                            " +
                       "        \"substitution_data\": {                                      " +
                       "          \"favorite_color\": \"SparkPost Orange\",                   " +
                       "          \"job\": \"Software Engineer\"                              " +
                       "        }                                                             " +
                       "      },                                                              " +
                       "      {                                                               " +
                       "        \"address\": {                                                " +
                       "          \"email\": \"abc@flintstone.com\",                          " +
                       "          \"name\": \"ABC\"                                           " +
                       "        },                                                            " +
                       "        \"tags\": [                                                   " +
                       "          \"driver\",                                                 " +
                       "          \"flintstone\"                                              " +
                       "        ],                                                            " +
                       "        \"metadata\": {                                               " +
                       "          \"age\": \"52\",                                            " +
                       "          \"place\": \"MD\"                                           " +
                       "        },                                                            " +
                       "        \"substitution_data\": {                                      " +
                       "          \"favorite_color\": \"Sky Blue\",                           " +
                       "          \"job\": \"Driver\"                                         " +
                       "        }                                                             " +
                       "      },                                                              " +
                       "      {                                                               " +
                       "        \"address\": {                                                " +
                       "          \"email\": \"fred.jones@flintstone.com\",                   " +
                       "          \"name\": \"Grad Student Office\",                          " +
                       "          \"header_to\": \"grad-student-office@flintstone.com\"       " +
                       "        },                                                            " +
                       "        \"tags\": [                                                   " +
                       "          \"driver\",                                                 " +
                       "          \"fred\",                                                   " +
                       "          \"flintstone\"                                              " +
                       "        ],                                                            " +
                       "        \"metadata\": {                                               " +
                       "          \"age\": \"33\",                                            " +
                       "          \"place\": \"NY\"                                           " +
                       "        },                                                            " +
                       "        \"substitution_data\": {                                      " +
                       "          \"favorite_color\": \"Bright Green\",                       " +
                       "          \"job\": \"Firefighter\"                                    " +
                       "        }                                                             " +
                       "      }                                                               " +
                       "    ]                                                                 " +
                       "  }                                                                   " +
                       "}                                                                     ";

            var response = JsonSerializer.Deserialize<RetrieveRecipientListResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("unique_id_4_graduate_students_list");
            response.Results.Recipients.Count.Should().Be(3);
        }

        [Fact]
        public void UpdateRecipientList_response_returns_expected_result()
        {
            var json = "{                                                   " +
                       "  \"results\": {                                    " +
                       "    \"total_rejected_recipients\": 0,               " +
                       "    \"total_accepted_recipients\": 2,               " +
                       "    \"id\": \"unique_id_4_graduate_students_list\", " +
                       "    \"name\": \"updated_graduate_students\"         " +
                       "  }                                                 " +
                       "}                                                   ";

            var response = JsonSerializer.Deserialize<UpdateRecipientListResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("unique_id_4_graduate_students_list");
            response.Results.Name.Should().Be("updated_graduate_students");

        }

        [Fact]
        public void ListRecipientLists_response_returns_expected_result()
        {
            var json = "{                                                                           " +
                       "  \"results\": [                                                            " +
                       "    {                                                                       " +
                       "      \"id\": \"unique_id_4_graduate_students_list\",                       " +
                       "      \"name\": \"graduate_students\",                                      " +
                       "      \"description\": \"An email list of graduate students at UMBC\",      " +
                       "      \"attributes\": {                                                     " +
                       "        \"internal_id\": 112,                                               " +
                       "        \"list_group_id\": 12321                                            " +
                       "      },                                                                    " +
                       "      \"total_accepted_recipients\": 3                                      " +
                       "    },                                                                      " +
                       "    {                                                                       " +
                       "      \"id\": \"unique_id_4_undergraduates\",                               " +
                       "      \"name\": \"undergraduate_students\",                                 " +
                       "      \"description\": \"An email list of undergraduate students at UMBC\", " +
                       "      \"attributes\": {                                                     " +
                       "        \"internal_id\": 111,                                               " +
                       "        \"list_group_id\": 11321                                            " +
                       "      },                                                                    " +
                       "      \"total_accepted_recipients\": 8                                      " +
                       "    }                                                                       " +
                       "  ]                                                                         " +
                       "}                                                                           ";

            var response = JsonSerializer.Deserialize<ListRecipientListsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
        }
    }
}