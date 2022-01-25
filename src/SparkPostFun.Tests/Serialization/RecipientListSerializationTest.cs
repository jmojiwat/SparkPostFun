using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class RecipientListSerializationTest
{
        [Fact]
    public void CreateRecipientList_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(
                new Address("wilmaflin@yahoo.com") { Name = "Wilma" }) 
            { Tags = new List<string>
                {
                    "greetings",
                    "prehistoric",
                    "fred",
                    "flintstone"
                },
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
            new(
                new Address("abc@flintstone.com") { Name = "ABC" }) 
            { Tags = new List<string>
                {
                    "driver",
                    "flintstone"
                },
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
            new(
                new Address("fred.jones@flintstone.com") { Name = "Grad Student Office", HeaderTo = "grad-student-office@flintstone.com" }) 
            { Tags = new List<string>
                {
                    "driver",
                    "fred",
                    "flintstone"
                },
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
        };
        
        var request = new CreateRecipientList(recipients)
        {
            Id = "unique_id_4_graduate_students_list",
            Name = "graduate_students",
            Description = "An email list of graduate students at UMBC",
            Attributes = new Dictionary<string, object> {
            {"internal_id", 112 },
            {"list_group_id", 12321 }
        }
                };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "id": "unique_id_4_graduate_students_list",
              "name": "graduate_students",
              "description": "An email list of graduate students at UMBC",
              "attributes": {
                "internal_id": 112,
                "list_group_id": 12321
              },
              "recipients": [
                {
                  "address": {
                    "email": "wilmaflin@yahoo.com",
                    "name": "Wilma"
                  },
                  "tags": [
                    "greeting",
                    "prehistoric",
                    "fred",
                    "flintstone"
                  ],
                  "metadata": {
                    "age": "24",
                    "place": "Bedrock"
                  },
                  "substitution_data": {
                    "favorite_color": "SparkPost Orange",
                    "job": "Software Engineer"
                  }
                },
                {
                  "address": {
                    "email": "abc@flintstone.com",
                    "name": "ABC"
                  },
                  "tags": [
                    "driver",
                    "flintstone"
                  ],
                  "metadata": {
                    "age": "52",
                    "place": "MD"
                  },
                  "substitution_data": {
                    "favorite_color": "Sky Blue",
                    "job": "Driver"
                  }
                },
                {
                  "address": {
                    "email": "fred.jones@flintstone.com",
                    "name": "Grad Student Office",
                    "header_to": "grad-student-office@flintstone.com"
                  },
                  "tags": [
                    "driver",
                    "fred",
                    "flintstone"
                  ],
                  "metadata": {
                    "age": "33",
                    "place": "NY"
                  },
                  "substitution_data": {
                    "favorite_color": "Bright Green",
                    "job": "Firefighter"
                  }
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("unique_id_4_graduate_students_list");
        obj.GetProperty("name").GetString().Should().Be("graduate_students");
        obj.GetProperty("description").GetString().Should().Be("An email list of graduate students at UMBC");

        obj.GetProperty("attributes").GetProperty("internal_id").GetInt32().Should().Be(112);
        obj.GetProperty("attributes").GetProperty("list_group_id").GetInt32().Should().Be(12321);

        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilmaflin@yahoo.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma");
        obj.GetProperty("recipients")[0].GetProperty("tags")[0].GetString().Should().Be("greetings");
        obj.GetProperty("recipients")[0].GetProperty("tags")[1].GetString().Should().Be("prehistoric");
        obj.GetProperty("recipients")[0].GetProperty("tags")[2].GetString().Should().Be("fred");
        obj.GetProperty("recipients")[0].GetProperty("tags")[3].GetString().Should().Be("flintstone");
        
        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("age").GetString().Should().Be("24");
        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("place").GetString().Should().Be("Bedrock");
        
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("favorite_color").GetString().Should().Be("SparkPost Orange");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("job").GetString().Should().Be("Software Engineer");

        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("abc@flintstone.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("name").GetString().Should().Be("ABC");
        obj.GetProperty("recipients")[1].GetProperty("tags")[0].GetString().Should().Be("driver");
        obj.GetProperty("recipients")[1].GetProperty("tags")[1].GetString().Should().Be("flintstone");
        
        obj.GetProperty("recipients")[1].GetProperty("metadata").GetProperty("age").GetString().Should().Be("52");
        obj.GetProperty("recipients")[1].GetProperty("metadata").GetProperty("place").GetString().Should().Be("MD");
        
        obj.GetProperty("recipients")[1].GetProperty("substitution_data").GetProperty("favorite_color").GetString().Should().Be("Sky Blue");
        obj.GetProperty("recipients")[1].GetProperty("substitution_data").GetProperty("job").GetString().Should().Be("Driver");

        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("email").GetString().Should().Be("fred.jones@flintstone.com");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("name").GetString().Should().Be("Grad Student Office");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("header_to").GetString().Should().Be("grad-student-office@flintstone.com");
        obj.GetProperty("recipients")[2].GetProperty("tags")[0].GetString().Should().Be("driver");
        obj.GetProperty("recipients")[2].GetProperty("tags")[1].GetString().Should().Be("fred");
        obj.GetProperty("recipients")[2].GetProperty("tags")[2].GetString().Should().Be("flintstone");
        
        obj.GetProperty("recipients")[2].GetProperty("metadata").GetProperty("age").GetString().Should().Be("33");
        obj.GetProperty("recipients")[2].GetProperty("metadata").GetProperty("place").GetString().Should().Be("NY");
        
        obj.GetProperty("recipients")[2].GetProperty("substitution_data").GetProperty("favorite_color").GetString().Should().Be("Bright Green");
        obj.GetProperty("recipients")[2].GetProperty("substitution_data").GetProperty("job").GetString().Should().Be("Firefighter");
    }

    [Fact]
    public void UpdateRecipientList_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(
                new Address("wilmaflin@yahoo.com") { Name = "Wilma" }) 
            { Tags = new List<string>
                {
                    "greetings",
                    "prehistoric",
                    "fred",
                    "flintstone"
                },
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
            new(
                new Address("abc@flintstone.com") { Name = "ABC" }) 
            { Tags = new List<string>
                {
                    "driver",
                    "flintstone"
                },
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
            new(
                new Address("fred.jones@flintstone.com") { Name = "Grad Student Office", HeaderTo = "grad-student-office@flintstone.com" }) 
            { Tags = new List<string>
                {
                    "driver",
                    "fred",
                    "flintstone"
                },
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
        };
        
        var request = new UpdateRecipientList
        {
            Name = "updated_graduate_students",
            Description = "An email list of graduate students at UMBC",
            Attributes = new Dictionary<string, object>
            {
                { "internal_id", 112 },
                { "list_group_id", 12321 }
            }, 
            Recipients = recipients
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "name": "updated_graduate_students",
              "description": "An email list of graduate students at UMBC",
              "attributes": {
                "internal_id": 112,
                "list_group_id": 12321
              },
              "recipients": [
                {
                  "address": {
                    "email": "wilmaflin@yahoo.com",
                    "name": "Wilma"
                  },
                  "tags": [
                    "greeting",
                    "prehistoric",
                    "fred",
                    "flintstone"
                  ],
                  "metadata": {
                    "age": "24",
                    "place": "Bedrock"
                  },
                  "substitution_data": {
                    "favorite_color": "SparkPost Orange",
                    "job": "Software Engineer"
                  }
                },
                {
                  "address": {
                    "email": "abc@flintstone.com",
                    "name": "ABC"
                  },
                  "tags": [
                    "driver",
                    "flintstone"
                  ],
                  "metadata": {
                    "age": "52",
                    "place": "MD"
                  },
                  "substitution_data": {
                    "favorite_color": "Sky Blue",
                    "job": "Driver"
                  }
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("name").GetString().Should().Be("updated_graduate_students");
        obj.GetProperty("description").GetString().Should().Be("An email list of graduate students at UMBC");

        obj.GetProperty("attributes").GetProperty("internal_id").GetInt32().Should().Be(112);
        obj.GetProperty("attributes").GetProperty("list_group_id").GetInt32().Should().Be(12321);

        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilmaflin@yahoo.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma");
        obj.GetProperty("recipients")[0].GetProperty("tags")[0].GetString().Should().Be("greetings");
        obj.GetProperty("recipients")[0].GetProperty("tags")[1].GetString().Should().Be("prehistoric");
        obj.GetProperty("recipients")[0].GetProperty("tags")[2].GetString().Should().Be("fred");
        obj.GetProperty("recipients")[0].GetProperty("tags")[3].GetString().Should().Be("flintstone");
        
        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("age").GetString().Should().Be("24");
        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("place").GetString().Should().Be("Bedrock");
        
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("favorite_color").GetString().Should().Be("SparkPost Orange");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("job").GetString().Should().Be("Software Engineer");

        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("abc@flintstone.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("name").GetString().Should().Be("ABC");
        obj.GetProperty("recipients")[1].GetProperty("tags")[0].GetString().Should().Be("driver");
        obj.GetProperty("recipients")[1].GetProperty("tags")[1].GetString().Should().Be("flintstone");
        
        obj.GetProperty("recipients")[1].GetProperty("metadata").GetProperty("age").GetString().Should().Be("52");
        obj.GetProperty("recipients")[1].GetProperty("metadata").GetProperty("place").GetString().Should().Be("MD");
        
        obj.GetProperty("recipients")[1].GetProperty("substitution_data").GetProperty("favorite_color").GetString().Should().Be("Sky Blue");
        obj.GetProperty("recipients")[1].GetProperty("substitution_data").GetProperty("job").GetString().Should().Be("Driver");
    }

    
    [Fact]
    public void CreateRecipientList_response_returns_expected_result()
    {
        const string json = "{                                                   " +
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
        const string json = "{                                                                     " +
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
        const string json = "{                                                   " +
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
        const string json = "{                                                                           " +
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