using System;
using Server.Network;
using Server;

namespace Server.Misc
{
	public class FoodDecayTimer : Timer
	{
		public static void Initialize()
		{
			new FoodDecayTimer().Start();
		}

		public FoodDecayTimer() : base( TimeSpan.FromMinutes( 20 ), TimeSpan.FromMinutes( 20 ) )
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			FoodDecay();			
		}

		public static void FoodDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				if ( state.Mobile != null && state.Mobile.AccessLevel == AccessLevel.Player ) // Check if player
				{
					HungerDecay( state.Mobile );
					ThirstDecay( state.Mobile );
				}
			}
		}

		public static void HungerDecay( Mobile m )
		{
			if ( m != null )
			{
				if ( m.Hunger >= 1 )
				{
					m.Hunger -= 1;
					// added to give hunger value a real meaning.
					if ( m.Hunger < 5 )
						m.SendMessage( "You are getting very hungry." );
					else if ( m.Hunger < 10 )
						m.SendMessage( "You are getting very hungry." );
				}	
				else
				{
					if ( m.Hits > 200 )
						m.Hits -= 200;
					m.SendMessage( "You are starving to death!" );
				}
			}
		}

		public static void ThirstDecay( Mobile m )
		{
			if ( m != null )
			{
				if ( m.Thirst >= 1 )
				{
					m.Thirst -= 1;
				// added to give thirst value a real meaning.
					if ( m.Thirst < 5 )
						m.SendMessage( "You are extremely thirsty." );
					else if ( m.Thirst < 10 )
						m.SendMessage( "You are getting thirsty." );
				}
				else
				{
					if ( m.Stam > 50 )
						m.Stam -= 50;
					m.SendMessage( "You are exhausted from thirst" );
				}
			}
		}
	}
}
