using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notion.Client;
using Notion;
using Notion.Client.Extensions;
using Insomnia.Agreemod.BI.Interfaces;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Generic;
using Insomnia.Agreemod.Data.Returns;
using Insomnia.Agreemod.BI.Options;
using Insomnia.Agreemod.Data.ViewModels.Output;
using Insomnia.Agreemod.General.Expansions;

namespace Insomnia.Agreemod.BI.Services
{
    public class Notion : INotion
    {
        /// <summary>
        /// Id - guid страницы
        /// Title - название страницы
        /// </summary>
        private static IList<DirectionDto> DirectionsCash = new List<DirectionDto>();
        private readonly object cashLock = new object();


        private readonly NotionClient _client;

        public Notion()
        {
            _client = NotionClientFactory.Create(new ClientOptions
            {
                AuthToken = "secret_53UctpAbVC9WQKtKexCPEhEw8FIkJNq5nq9nfemeR5x"
            });
        }

        public async Task<PeoplesReturn> GetPeoples()
        {
            try
            {
                var peoples = new List<PeopleDto>();

                peoples.AddRange(await GetVolunteers());
                peoples.AddRange(await GetPrticipants());

                var result = peoples.Where(x => !String.IsNullOrEmpty(x.Name)).Select(x => new PeopleOutput()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Nickname = x.Nickname,
                    Directions = x.Directions.RemoveSystemsLocations() ?? x.OwnedbyLocation,
                    Locations = x.LeaderLocations,
                    Email = x.Email,
                    Phone = x.Phone,
                    Position = x.GetPosition(),
                    Avatar = x.Avatar,
                    NutritionFeatures = x.NutritionFeatures,
                    ArrivalDate = x.ArrivalDate,
                    DepartureDate = x.DepartureDate,
                    FoodType = x.GetFoodType(),
                    BadgeColor = x.GetBadgeColor(),
                }).ToArray();

               return new PeoplesReturn()
                {
                    Success = true,
                    Peoples = result,
                };
            }
            catch(Exception ex)
            {
                return new PeoplesReturn()
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    Peoples = new PeopleOutput[] { }
                };
            }
        }

        public async Task<LocationsReturn> GetLocations()
        {
            try
            {
                var database = await GetDatabase(DatabaseIds.Locations);

                var locations = await Task.WhenAll(database.Results.Select(async x => new LocationDto()
                {
                    Name = (x.Properties[TablePropertiesNaming.LocationName] as TitlePropertyValue).Title.FirstOrDefault()?.PlainText,
                    Directions = await GetDirectionsNaming((x.Properties[TablePropertiesNaming.Direction] as RelationPropertyValue).Relation),
                    Tags = (x.Properties[TablePropertiesNaming.Tags] as MultiSelectPropertyValue).MultiSelect.Select(x => x.Name).ToArray()
                }));

                return new LocationsReturn()
                {
                    Success = true,
                    Locations = locations,
                };
            }
            catch (Exception ex)
            {
                return new LocationsReturn()
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    Locations = new LocationDto[] {}
                };
            }
        }

        private async Task<IList<PeopleDto>> GetVolunteers()
        {
            var filter = new DatabasesQueryParameters() { Sorts = new List<Sort>() { new Sort() { Property = TablePropertiesNaming.VolunteerName, Direction = Direction.Ascending, Timestamp = Timestamp.CreatedTime } } };

            var database = new PaginatedList<Page>();

            List<PeopleDto> peoples = new List<PeopleDto>();

            do
            {
                filter.StartCursor = database.NextCursor;

                database = await GetDatabase(DatabaseIds.Volunteers, filter);

                peoples.AddRange((await Task.WhenAll(database.Results.Select(async x => new PeopleDto()
                {
                    Id = (x.Properties[TablePropertiesNaming.VolunteerId] as FormulaPropertyValue).Formula?.String,
                    Name = (x.Properties[TablePropertiesNaming.VolunteerName] as TitlePropertyValue).Title.FirstOrDefault()?.PlainText,
                    Nickname = (x.Properties[TablePropertiesNaming.VolunteerNickname] as RichTextPropertyValue).RichText.FirstOrDefault()?.PlainText,
                    Email = (x.Properties[TablePropertiesNaming.Email] as EmailPropertyValue).Email,
                    Phone = (x.Properties[TablePropertiesNaming.Phone] as PhoneNumberPropertyValue).PhoneNumber,
                    Position = (x.Properties[TablePropertiesNaming.VolunteerPosition] as RichTextPropertyValue).RichText.FirstOrDefault()?.PlainText,
                    Directions = (x.Properties[TablePropertiesNaming.VolunteerDirection] as MultiSelectPropertyValue).MultiSelect.Select(x => x.Name).ToArray(),
                    WhoIt = (x.Properties[TablePropertiesNaming.VolunteerWhoIt] as FormulaPropertyValue).Formula?.String,
                    Avatar = (x.Properties[TablePropertiesNaming.VolunteerAvatar] as FilesPropertyValue).Files?.Select(x => x as UploadedFileWithName).FirstOrDefault()?.File?.Url,
                    VolunteerDirections = await GetDirectionsNaming((x.Properties[TablePropertiesNaming.IsVolunteer] as RelationPropertyValue).Relation),
                    FoodType = (x.Properties[TablePropertiesNaming.VolunteerFoodType] as SelectPropertyValue).Select?.Name,
                    LeaderLocations = await GetDirectionsNaming((x.Properties[TablePropertiesNaming.VolunteerLeader] as RelationPropertyValue).Relation),
                    ArrivalDate = (x.Properties[TablePropertiesNaming.VolunteerDates] as DatePropertyValue).Date?.Start,
                    DepartureDate = (x.Properties[TablePropertiesNaming.VolunteerDates] as DatePropertyValue).Date?.End,
                }))).ToList());
            }
            while (database.Results.Count() == 100);

            return peoples;
        }

        private async Task<IList<PeopleDto>> GetPrticipants()
        {
            var filter = new DatabasesQueryParameters() { Sorts = new List<Sort>() { new Sort() { Property = TablePropertiesNaming.VolunteerName, Direction = Direction.Ascending, Timestamp = Timestamp.CreatedTime } } };

            var database = new PaginatedList<Page>();

            List<PeopleDto> peoples = new List<PeopleDto>();

            do
            {
                filter.StartCursor = database.NextCursor;

                database = await GetDatabase(DatabaseIds.Prticipants, filter);

                peoples.AddRange((await Task.WhenAll(database.Results.Select(async x => new PeopleDto()
                {
                    Id = (x.Properties[TablePropertiesNaming.PrticipantId] as FormulaPropertyValue).Formula?.String,
                    Name = (x.Properties[TablePropertiesNaming.PrticipantName] as TitlePropertyValue).Title.FirstOrDefault()?.PlainText,
                    Nickname = (x.Properties[TablePropertiesNaming.PrticipantNickname] as RichTextPropertyValue).RichText.FirstOrDefault()?.PlainText,
                    Position = (x.Properties[TablePropertiesNaming.PrticipantPosition] as RichTextPropertyValue).RichText.FirstOrDefault()?.PlainText,
                    OwnedbyLocation = await GetLocationNaming((x.Properties[TablePropertiesNaming.PrticipantLocation] as RelationPropertyValue).Relation),
                    Directions = await GetDirectionsNaming((x.Properties[TablePropertiesNaming.PrticipantDirection] as RelationPropertyValue).Relation),
                    WhoIt = (x.Properties[TablePropertiesNaming.PrticipantWhoIt] as MultiSelectPropertyValue).MultiSelect.FirstOrDefault()?.Name,
                    Avatar = (x.Properties[TablePropertiesNaming.PrticipantAvatar] as FilesPropertyValue).Files?.Select(x => x as UploadedFileWithName).FirstOrDefault()?.File?.Url,
                    ArrivalDate = (x.Properties[TablePropertiesNaming.VolunteerDates] as DatePropertyValue).Date?.Start,
                    DepartureDate = (x.Properties[TablePropertiesNaming.VolunteerDates] as DatePropertyValue).Date?.End,
                    FoodType = (x.Properties[TablePropertiesNaming.PrticipantTypeFood] as SelectPropertyValue).Select?.Name,
                    NutritionFeatures = (x.Properties[TablePropertiesNaming.IsVegan] as CheckboxPropertyValue).Checkbox ? "Веган" : String.Empty,
                }))).ToList());
            }
            while (database.Results.Count() == 100);

            return peoples;
        }

        private async Task<PaginatedList<Page>> GetDatabase(string databaseId, DatabasesQueryParameters queryParameters = null)
        {
            if (queryParameters is null)
                queryParameters = new DatabasesQueryParameters();

            return await _client.Databases.QueryAsync(databaseId, queryParameters);
        }

        private async Task<string[]> GetLocationNaming(List<ObjectId> objects)
        {
            return (await Task.WhenAll(objects.Select(async x => await GetLocationName(x.Id)))).ToArray();
        }

        private async Task<string[]> GetDirectionsNaming(List<ObjectId> objects)
        {
            return (await Task.WhenAll(objects.Select(async x => await GetDirectionName(x.Id)))).ToArray();
        }

        private async Task<string> GetLocationName(string id)
        {
            var result = DirectionsCash.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {

                var page = await _client.Pages.RetrieveAsync(id);

                result = new DirectionDto()
                {
                    Id = id,
                    Name = (page.Properties[TablePropertiesNaming.LocationName] as TitlePropertyValue).Title.FirstOrDefault()?.PlainText
                };

                AddCash(result);
            }

            return result.Name;
        }

        private async Task<string> GetDirectionName(string id)
        {
            var result = GetCash(id);

            if (result == null)
            {
                var page = await _client.Pages.RetrieveAsync(id);

                result = new DirectionDto()
                {
                    Id = id,
                    Name = (page.Properties[TablePropertiesNaming.TitlePageName] as TitlePropertyValue).Title.FirstOrDefault()?.PlainText
                };

                AddCash(result);
            }

            return result.Name;
        }

        private DirectionDto GetCash(string id)
        {
            lock (cashLock)
            {
                return DirectionsCash.FirstOrDefault(x => x.Id == id);
            }
        }

        private void AddCash(DirectionDto model)
        {
            lock (cashLock)
            {
                DirectionsCash.Add(model);
            }
        }
    }
}
