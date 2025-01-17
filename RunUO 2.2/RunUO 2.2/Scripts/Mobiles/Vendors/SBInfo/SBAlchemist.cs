using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{  
				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 100, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 100, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 100, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 100, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 100, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 100, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 100, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 100, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 100, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 100, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 100, 0xF0A, 0 ) );
				Add( new GenericBuyInfo( "Lesser Toxic Potion", typeof( LesserToxicPotion ), 700, 100, 0xF0D, 64 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 100, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 100, 0xF0B, 0 ) );

////////////////////////////////////////////////////// Novice Combat Potions
				Add( new GenericBuyInfo( "Novice Potion Of Archery", typeof( NovicePotionOfArchery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fencing", typeof( NovicePotionOfFencing ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfMaceFighting ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfMagery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfParry ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfSwordsmanship ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfWrestling ), 100, 100, 0xE29, 45 ) );

////////////////////////////////////////////////////// Novice Crafting Potions
				Add( new GenericBuyInfo( "Novice Potion Of Alchemy", typeof( NovicePotionOfAlchemy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Blacksmithy", typeof( NovicePotionOfBlacksmithy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfCarpentry ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfCooking ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfFletching ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfInscription ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfTailoring ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Tinkering", typeof( NovicePotionOfTinkering ), 100, 100, 0xE29, 60 ) );

////////////////////////////////////////////////////// Novice Misc Potions
				Add( new GenericBuyInfo( "Novice Potion Of Animal Taming", typeof( NovicePotionOfAnimalTaming ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Discordance", typeof( NovicePotionOfDiscordance ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fishing", typeof( NovicePotionOfFishing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Herding", typeof( NovicePotionOfHerding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Hiding", typeof( NovicePotionOfHiding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Lumberjacking", typeof( NovicePotionOfLumberjacking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magic Resist", typeof( NovicePotionOfMagicResist ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mining", typeof( NovicePotionOfMining ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Peacemaking", typeof( NovicePotionOfPeacemaking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Poisoning", typeof( NovicePotionOfPoisoning ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Provocation", typeof( NovicePotionOfProvocation ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Snooping", typeof( NovicePotionOfSnooping ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Stealing", typeof( NovicePotionOfStealing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Veterinary", typeof( NovicePotionOfVeterinary ), 100, 100, 0xE29, 285 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GreaterAgilityPotion ), 700 );
				Add( typeof( GreaterCurePotion ), 700 );
				Add( typeof( GreaterExplosionPotion ), 700 );
				Add( typeof( GreaterHealPotion ), 700 );
				Add( typeof( GreaterLightningPotion ), 700 );
				Add( typeof( GreaterManaPotion ), 700 );
				Add( typeof( GreaterMindPotion ), 700 );
				Add( typeof( GreaterPoisonPotion ), 700 );
				Add( typeof( GreaterShatterPotion ), 700 );
				Add( typeof( GreaterStrengthPotion ), 700 );

				Add( typeof( CurePotion ), 300 );
				Add( typeof( ExplosionPotion ), 300 );
				Add( typeof( HealPotion ), 300 );
				Add( typeof( LightningPotion ), 300 );
				Add( typeof( ManaPotion ), 300 );
				Add( typeof( PoisonPotion ), 300 );
				Add( typeof( ShatterPotion ), 300 );

				Add( typeof( AgilityPotion ), 50 );
				Add( typeof( LesserCurePotion ), 50 );
				Add( typeof( LesserExplosionPotion ), 50 );
				Add( typeof( LesserHealPotion ), 50 );
				Add( typeof( LesserLightningPotion ), 50 );
				Add( typeof( LesserManaPotion ), 50 );
				Add( typeof( LesserPoisonPotion ), 50 );
				Add( typeof( LesserShatterPotion ), 50 );
				Add( typeof( MindPotion ), 50 );
				Add( typeof( NightSightPotion ), 50 );
				Add( typeof( RefreshPotion ), 50 );
				Add( typeof( StrengthPotion ), 50 );

				Add( typeof( NovicePotionOfArchery ), 50 );
				Add( typeof( NovicePotionOfFencing ), 50 );
				Add( typeof( NovicePotionOfMaceFighting ), 50 );
				Add( typeof( NovicePotionOfMagery ), 50 );
				Add( typeof( NovicePotionOfParry ), 50 );
				Add( typeof( NovicePotionOfSwordsmanship ), 50 );
				Add( typeof( NovicePotionOfWrestling ), 50 );

				Add( typeof( NovicePotionOfAlchemy ), 50 );
				Add( typeof( NovicePotionOfBlacksmithy ), 50 );
				Add( typeof( NovicePotionOfCarpentry ), 50 );
				Add( typeof( NovicePotionOfCooking ), 50 );
				Add( typeof( NovicePotionOfFletching ), 50 );
				Add( typeof( NovicePotionOfInscription ), 50 );
				Add( typeof( NovicePotionOfTailoring ), 50 );
				Add( typeof( NovicePotionOfTinkering ), 50 );

				Add( typeof( NovicePotionOfAnimalTaming ), 50 );
				Add( typeof( NovicePotionOfDiscordance ), 50 );
				Add( typeof( NovicePotionOfFishing ), 50 );
				Add( typeof( NovicePotionOfHerding ), 50 );
				Add( typeof( NovicePotionOfHiding ), 50 );
				Add( typeof( NovicePotionOfLumberjacking ), 50 );
				Add( typeof( NovicePotionOfMagicResist ), 50 );
				Add( typeof( NovicePotionOfMining ), 50 );

				Add( typeof( NovicePotionOfPeacemaking ), 50 );
				Add( typeof( NovicePotionOfPoisoning ), 50 );
				Add( typeof( NovicePotionOfProvocation ), 50 );
				Add( typeof( NovicePotionOfSnooping ), 50 );
				Add( typeof( NovicePotionOfStealing ), 50 );
				Add( typeof( NovicePotionOfVeterinary ), 50 );

				Add( typeof( HeatingStand ), 50 );
				Add( typeof( MortarPestle ), 50 );

				Add( typeof( Bone ), 2 ); 
				Add( typeof( RibCage ), 5 ); 
				Add( typeof( BonePile ), 10 );
			}
		}
	}
}
