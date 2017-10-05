using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class MyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

      /*  // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");


        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    */
    }

    /*public class User
    {
        public string username;
        public string email;

        public User()
        {
        }

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }

    private void writeNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
        mDatabaseRef.Child("users").Child(userId).Child("username").SetValueAsync(name);
    }

    public class LeaderboardEntry
    {
        public string uid;
        public int score = 0;

        public LeaderboardEntry()
        {
        }

        public LeaderboardEntry(string uid, int score)
        {
            this.uid = uid;
            this.score = score;
        }

        public Dictionary<string, Object> ToDictionary()
        {
            Dictionary<string, Object> result = new Dictionary<string, Object>();
            result["uid"] = uid;
            result["score"] = score;

            return result;
        }
    }

    private void WriteNewScore(string userId, int score)
    {
        // Create new entry at /user-scores/$userid/$scoreid and at
        // /leaderboard/$scoreid simultaneously
        string key = mDatabase.Child("scores").Push().Key;
        LeaderBoardEntry entry = new LeaderBoardEntry(userId, score);
        Dictionary<string, Object> entryValues = entry.ToDictionary();

        Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
        childUpdates["/scores/" + key] = entryValues;
        childUpdates["/user-scores/" + userId + "/" + key] = entryValues;

        mDatabase.UpdateChildrenAsync(childUpdates);
    }

    private void AddScoreToLeaders(string email,
                               long score,
                               DatabaseReference leaderBoardRef)
    {

        leaderBoardRef.RunTransaction(mutableData => {
            List<object> leaders = mutableData.Value as List<object>
    
      if (leaders == null)
            {
                leaders = new List<object>();
            }
            else if (mutableData.ChildrenCount >= MaxScores)
            {
                long minScore = long.MaxValue;
                object minVal = null;
                foreach (var child in leaders)
                {
                    if (!(child is Dictionary<string, object>)) continue;
                    long childScore = (long)
                                ((Dictionary<string, object>)child)["score"];
                    if (childScore < minScore)
                    {
                        minScore = childScore;
                        minVal = child;
                    }
                }
                if (minScore > score)
                {
                    // The new score is lower than the existing 5 scores, abort.
                    return TransactionResult.Abort();
                }

                // Remove the lowest score.
                leaders.Remove(minVal);
            }

            // Add the new high score.
            Dictionary<string, object> newScoreMap =
                             new Dictionary<string, object>();
            newScoreMap["score"] = score;
            newScoreMap["email"] = email;
            leaders.Add(newScoreMap);
            mutableData.Value = leaders;
            return TransactionResult.Success(mutableData);
        });
    }

    // Update is called once per frame
    void Update () {
		
	}*/
}
