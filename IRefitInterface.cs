using System.Threading.Tasks;
using TeamsContactsGroupCreator.Model;
using Refit;

namespace TeamsContactsGroupCreator
{
    public interface IRefitInterface
    {
        [Post("/users/searchV2?includeDLs=true&includeBots=true&enableGuest=true&skypeTeamsInfo=true")]
        Task<SearchDLModel> GetDLSearchResults([Body]string body);

        [Get("/users/{objectid}/groupmembers?resolveNestedGroups=false")]
        Task<DistributionListModel> GetDistributionListUsers([AliasAs("objectid")] string objectid);

        [Post("/contacts/buddylist?migrationRequested=true&federatedContactsSupported=true")]
        Task<CreateGroupResponseModel> CreateContactsGroup([Body]GroupModel groupModel);
    }
}