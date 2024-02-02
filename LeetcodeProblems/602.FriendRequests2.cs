namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/friend-requests-ii-who-has-the-most-friends/description/
/// </summary>
public class FriendRequests2
{
    [Fact]
    public void Test()
    {
        var sql = """
                  select id, count(fid) as num from (
                  SELECT requester_id as id, accepter_id fid FROM RequestAccepted
                  union all
                  SELECT accepter_id as id, requester_id fid FROM RequestAccepted) group by id order by num desc limit 1;
                  """;
    }
}