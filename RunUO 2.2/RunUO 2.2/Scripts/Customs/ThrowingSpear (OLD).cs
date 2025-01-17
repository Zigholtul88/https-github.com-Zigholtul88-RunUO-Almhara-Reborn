using System;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x1403, 0x1402 )]
	public class ThrowingShortSpear : Item
	{
		public override string DefaultName
		{
			get { return "a throwing short spear"; }
		}

		[Constructable]
		public ThrowingShortSpear() : base( 0x1403 )
		{
			Weight = 4.0;
			Layer = Layer.OneHanded;
		}

		public ThrowingShortSpear( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Items.Contains( this ) )
			{
				InternalTarget t = new InternalTarget( this );
				from.Target = t;
			}
			else
			{
				from.SendMessage( "You must be holding that weapon to use it." );
			}
		}

		private class InternalTarget : Target
		{
			private ThrowingShortSpear m_Spear;

			public InternalTarget( ThrowingShortSpear spear ) : base( 10, false, TargetFlags.Harmful )
			{
				m_Spear = spear;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Spear.Deleted )
				{
					return;
				}
				else if ( !from.Items.Contains( m_Spear ) )
				{
					from.SendMessage( "You must be holding that weapon to use it." );
				}
				else if ( targeted is Mobile )
				{
					Mobile m = (Mobile)targeted;

					if ( m != from && from.HarmfulCheck( m ) )
					{
						Direction to = from.GetDirectionTo( m );
						from.Direction = to;
						from.Animate( from.Mounted ? 26 : 9, 7, 1, true, false, 0 );
						if ( Utility.RandomDouble() >= (Math.Sqrt( m.Dex / 100.0 ) * 0.8) )
						{
							from.MovingEffect( m, 0x1BFE, 7, 1, false, false, 0x481, 0 );
							AOS.Damage( m, from, Utility.Random( 5, from.Str * 4 ), 100, 0, 0, 0, 0 );
							m_Spear.MoveToWorld( m.Location, m.Map );
						}
						else
						{
							int x = 0, y = 0;
							switch ( to & Direction.Mask )
							{
								case Direction.North: --y; break;
								case Direction.South: ++y; break;
								case Direction.West: --x; break;
								case Direction.East: ++x; break;
								case Direction.Up: --x; --y; break;
								case Direction.Down: ++x; ++y; break;
								case Direction.Left: --x; ++y; break;
								case Direction.Right: ++x; --y; break;
							}
							x += Utility.Random( -1, 3 );
							y += Utility.Random( -1, 3 );
							x += m.X;
							y += m.Y;
							m_Spear.MoveToWorld( new Point3D( x, y, m.Z ), m.Map );
							from.MovingEffect( m_Spear, 0x1BFE, 7, 1, false, false, 0x481, 0 );
							from.SendMessage( "You miss." );
						}
					}
				}
			}
		}
	}
}