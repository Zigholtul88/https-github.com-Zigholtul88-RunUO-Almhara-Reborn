using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a cow corpse" )]
	public class Cow : BaseCreature
	{
		private DateTime m_MilkedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MilkedOn
		{
			get { return m_MilkedOn; }
			set { m_MilkedOn = value; }
		}

		private int m_Milk;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Milk
		{
			get { return m_Milk; }
			set { m_Milk = value; }
		}

		[Constructable]
		public Cow() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a cow";
			Body = Utility.RandomList( 0xD8, 0xE7 );
			BaseSoundID = 0x78;

			SetStr( 30 );
			SetDex( 15 );
			SetInt( 5 );

			SetHits( 36 );
			SetMana( 100 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );

			SetSkill( SkillName.MagicResist, 5.5 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 10;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 11.1;

			if ( Core.AOS && Utility.Random( 1000 ) == 0 ) // 0.1% chance to have mad cows
				FightMode = FightMode.Closest;

		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawBeefPorterhouse(), from);
                              corpse.AddCarvedItem(new RawBeefPrimeRib(), from);
                              corpse.AddCarvedItem(new RawBeefRibeye(), from);
                              corpse.AddCarvedItem(new RawBeefRibs(), from);
                              corpse.AddCarvedItem(new RawBeefRoast(), from);
                              corpse.AddCarvedItem(new RawBeefSirloin(), from);
                              corpse.AddCarvedItem(new RawBeefTBone(), from);
                              corpse.AddCarvedItem(new RawBeefTenderloin(), from);
                              corpse.AddCarvedItem(new RawGroundBeef(), from);
                              corpse.AddCarvedItem(new Hides(12), from);

                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some bovine parts." ); 
			}
                }

		public override void OnDoubleClick( Mobile from )
		{
			base.OnDoubleClick( from );

			int random = Utility.Random( 100 );

			if ( random < 5 )
				Tip();
			else if ( random < 20 )
				PlaySound( 120 );
			else if ( random < 40 )
				PlaySound( 121 );
		}

		public void Tip()
		{
			PlaySound( 121 );
			Animate( 8, 0, 3, true, false, 0 );
		}

		public bool TryMilk( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
				from.SendLocalizedMessage( 1080400 ); // You can not milk the cow from this location.
			if ( Controlled && ControlMaster != from )
				from.SendLocalizedMessage( 1071182 ); // The cow nimbly escapes your attempts to milk it.
			if ( m_Milk == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
				from.SendLocalizedMessage( 1080198 ); // This cow can not be milked now. Please wait for some time.
			else
			{
				if ( m_Milk == 0 )
					m_Milk = 4;

				m_MilkedOn = DateTime.Now;
				m_Milk--;

				return true;
			}

			return false;
		}

		public Cow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Milk );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version > 0 )
			{
				m_MilkedOn = reader.ReadDateTime();
				m_Milk = reader.ReadInt();
			}
		}
	}
}