using Discord;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
	public global::Discord.Discord discord;

	public string status_Details = "In Menu";

	public string status_State;

	public string status_largeText;

	public string status_smallText;

	public string status_largeImage;

	public string status_smallImage;

	public int currentPartySize;

	public int maxPartySize = 4;

	public int timeElapsed;

	public string status_partyId;

	private float timeAtLastStatusUpdate;

	private bool activityEnabled;

	private bool appQuitting;

	public static DiscordController Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void Start()
	{
		discord = new global::Discord.Discord(1174275017694007318L, 1uL);
		Application.quitting += Application_quitting;
	}

	private void OnDisable()
	{
		Application.quitting -= Application_quitting;
		discord.Dispose();
	}

	private void Application_quitting()
	{
		appQuitting = true;
	}

	private void Update()
	{
		try
		{
			discord.RunCallbacks();
		}
		catch
		{
			Object.Destroy(this);
		}
	}

	public void UpdateStatus(bool clear)
	{
		if ((clear && !activityEnabled) || Time.realtimeSinceStartup - timeAtLastStatusUpdate < 2f)
		{
			return;
		}
		timeAtLastStatusUpdate = Time.realtimeSinceStartup;
		try
		{
			ActivityManager activityManager = discord.GetActivityManager();
			activityManager.RegisterSteam(1966720u);
			Activity activity = new Activity
			{
				Details = status_Details,
				State = status_State,
				Assets = 
				{
					LargeImage = status_largeImage,
					LargeText = status_largeText,
					SmallImage = status_smallImage,
					SmallText = status_smallText
				},
				Party = 
				{
					Id = status_partyId,
					Size = 
					{
						CurrentSize = currentPartySize,
						MaxSize = maxPartySize
					}
				}
			};
			if (clear)
			{
				activity.Details = "In menu";
				activity.State = "";
				activity.Party.Size.CurrentSize = 1;
			}
			activityManager.UpdateActivity(activity, delegate(Result result)
			{
				if (result != 0)
				{
					Debug.LogWarning("Error while updating Discord activity status!");
				}
				else
				{
					activityEnabled = true;
				}
			});
		}
		catch
		{
			Object.Destroy(this);
		}
	}
}
