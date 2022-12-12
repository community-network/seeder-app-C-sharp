namespace seeder_app_C_sharp.Threads.SeederTypes;

internal abstract class State
{
    protected States states;
    protected Structs.CurrentServer current_server;
    protected Structs.CurrentServer old_server;
    protected Config config;
    protected Structs.GameInfo game_info;
    protected bool a_hour;
    protected bool a_minute;
    protected string old_game_id;
    protected string current_game_id;

    public abstract void Handle(Init seeder_type);

    public void Setup(States states, Structs.CurrentServer current_server, Structs.CurrentServer old_server, Config config, Structs.GameInfo game_info, bool a_hour, bool a_minute, string old_game_id, string current_game_id)
    {
        this.states = states;
        this.current_server = current_server;
        this.old_server = old_server;
        this.config = config;
        this.game_info = game_info;
        this.a_hour = a_hour;
        this.a_minute = a_minute;
        this.old_game_id = old_game_id;
        this.current_game_id = current_game_id;
    }
}

internal class Init
{

    State state;
    // Constructor
    public Init(State state)
    {
        this.State = state;
    }

    public void Setup(States states, Structs.CurrentServer current_server, Structs.CurrentServer old_server, Config config, Structs.GameInfo game_info, bool a_hour, bool a_minute, string old_game_id, string current_game_id)
    {
        state.Setup(states, current_server, old_server, config, game_info, a_hour, a_minute, old_game_id, current_game_id);
    }

    // Gets or sets the state
    public State State
    {
        get { return state; }
        set
        {
            state = value;
            // Debug.WriteLine("State: " + state.GetType().Name);
        }
    }
    public void Run()
    {
        state.Handle(this);
    }
}
