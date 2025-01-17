using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Engines.MLQuests.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class FharlunesBow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Arrow ); } }
		
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 2; } }
		public override int AosMaxDamage{ get{ return 5; } }
		public override int AosSpeed{ get{ return 20; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public FharlunesBow() : base( 0x13B2 )
		{
			Name = "Fharlune's Bow - (Lv. 1)";
			Weight = 6.0;
			Layer = Layer.TwoHanded;
                        Hue = 1591;
			LootType = LootType.Blessed;

			Attributes.WeaponDamage = 100;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 1 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 1 in order to equip this." );
				return false;
			}
		}

		public FharlunesBow( Serial serial ) : base( serial )
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