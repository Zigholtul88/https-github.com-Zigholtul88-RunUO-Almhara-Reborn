using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public class PassageOfLostSoulsTeleporter : Teleporter
	{
		public override int LabelNumber{ get{ return 1049382; } } // a magical teleporter

		[Constructable]
		public PassageOfLostSoulsTeleporter()
		{
		}
 
		public override bool OnMoveOver( Mobile m )
		{
                        Item item = m.Backpack.FindItemByType(typeof( PassageOfLostSoulsKey ) );
	                if ( item != null )
	                {
	                if ( item != this )
	                {
					 m.PlaySound( 0x014 ); // wind 1
					 m.PlaySound( 0x015 ); // wind 2
					 m.PlaySound( 0x016 ); // wind 3
					 m.PlaySound( 0x028 ); // thundr01
					 m.PlaySound( 0x028 ); // thundr01
					 m.PlaySound( 0x4D5 ); // defense mastery

		                         m.SendMessage( "You will be teleported in 7 seconds." );
			}
                        else
                        {
				         return true;
                        } 
				 StartTeleport( m );
			         return false;
                      }

		      m.SendMessage( "Access to Passage of Lost Souls requires the proper key." );
		      return true;
		}

		public PassageOfLostSoulsTeleporter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}