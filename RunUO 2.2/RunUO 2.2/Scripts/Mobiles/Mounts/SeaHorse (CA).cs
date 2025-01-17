using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a sea horse corpse" )]
	public class SeaHorse : BaseMount
	{
		[Constructable]
		public SeaHorse() : base( "a sea horse", 0x114, 0x3E90, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.35 )
		{
			SetStr( 58, 100 );
			SetDex( 56, 75 );
			SetInt( 16, 30 );

			SetHits( 641, 754 );
			SetMana( 0 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 25.3, 40.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.Wrestling, 35.1, 45.0 );

			Fame = 300;
			Karma = -300;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public override int GetIdleSound() { return 0x478; } 
		public override int GetAngerSound() { return 0x479; } 
		public override int GetAttackSound() { return 0x47A; } 
		public override int GetHurtSound() { return 0x47B; } 
		public override int GetDeathSound() { return 0x47C; }

		public SeaHorse( Serial serial ) : base( serial )
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