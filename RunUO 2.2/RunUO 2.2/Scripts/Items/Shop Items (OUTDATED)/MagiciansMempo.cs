using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MagiciansMempo : PlateMempo, ITokunoDyable
        {
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override int BaseColdResistance{ get{ return 8; } } 
		public override int BaseEnergyResistance{ get{ return 7; } } 
		public override int BasePhysicalResistance{ get{ return 5; } } 
		public override int BasePoisonResistance{ get{ return 6; } } 
		public override int BaseFireResistance{ get{ return 10; } } 
      
                [Constructable]
		public MagiciansMempo()
		{
                        Name = "Magician's Mempo";
                        Hue = 1151;

			LootType = LootType.Blessed;

                        ArmorAttributes.MageArmor = 1;
                        Attributes.BonusInt = 5;
                        Attributes.EnhancePotions = 25;
                        Attributes.LowerManaCost = 15;
                        Attributes.LowerRegCost = 15;
                        Attributes.RegenMana = 5;
                        Attributes.SpellDamage = 25;
		}

		public MagiciansMempo( Serial serial ) : base( serial )
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
