using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	public class KameronKoveAnimalTrainer : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public KameronKoveAnimalTrainer() : base( "the animal trainer" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBKameronKoveAnimalTrainer() );
		}

		public override void InitOutfit()
		{
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

			SetStr( 272 );
			SetDex( 245 );
			SetInt( 223 );

			SetSkill( SkillName.AnimalLore, 64.0, 100.0 );
			SetSkill( SkillName.AnimalTaming, 90.0, 100.0 );
			SetSkill( SkillName.Veterinary, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 65.0, 70.0 );

			PackGold( 23, 35 );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 386;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 390;
				Name = NameList.RandomName( "male" );
			}
                }

		private class StableEntry : ContextMenuEntry
		{
			private KameronKoveAnimalTrainer m_Trainer;
			private Mobile m_From;

			public StableEntry( KameronKoveAnimalTrainer trainer, Mobile from ) : base( 6126, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.BeginStable( m_From );
			}
		}

		private class ClaimListGump : Gump
		{
			private KameronKoveAnimalTrainer m_Trainer;
			private Mobile m_From;
			private List<BaseCreature> m_List;

			public ClaimListGump( KameronKoveAnimalTrainer trainer, Mobile from, List<BaseCreature> list ) : base( 50, 50 )
			{
				m_Trainer = trainer;
				m_From = from;
				m_List = list;

				from.CloseGump( typeof( ClaimListGump ) );

				AddPage( 0 );

				AddBackground( 0, 0, 325, 50 + (list.Count * 20), 9250 );
				AddAlphaRegion( 5, 5, 315, 40 + (list.Count * 20) );

				AddHtml( 15, 15, 275, 20, "<BASEFONT COLOR=#FFFFFF>Select a pet to retrieve from the stables:</BASEFONT>", false, false );

				for ( int i = 0; i < list.Count; ++i )
				{
					BaseCreature pet = list[i];

					if ( pet == null || pet.Deleted )
						continue;

					AddButton( 15, 39 + (i * 20), 10006, 10006, i + 1, GumpButtonType.Reply, 0 );
					AddHtml( 32, 35 + (i * 20), 275, 18, String.Format( "<BASEFONT COLOR=#C0C0EE>{0}</BASEFONT>", pet.Name ), false, false );
				}
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				int index = info.ButtonID - 1;

				if ( index >= 0 && index < m_List.Count )
					m_Trainer.EndClaimList( m_From, m_List[index] );
			}
		}

		private class ClaimAllEntry : ContextMenuEntry
		{
			private KameronKoveAnimalTrainer m_Trainer;
			private Mobile m_From;

			public ClaimAllEntry( KameronKoveAnimalTrainer trainer, Mobile from ) : base( 6127, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.Claim( m_From );
			}
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from.Alive )
			{
				list.Add( new StableEntry( this, from ) );

				if ( from.Stabled.Count > 0 )
					list.Add( new ClaimAllEntry( this, from ) );
			}

			base.AddCustomContextEntries( from, list );
		}

		public static int GetMaxStabled( Mobile from )
		{
			double taming = from.Skills[SkillName.AnimalTaming].Value;
			double anlore = from.Skills[SkillName.AnimalLore].Value;
			double vetern = from.Skills[SkillName.Veterinary].Value;
			double sklsum = taming + anlore + vetern;

			int max;

			if ( sklsum >= 240.0 )
				max = 5;
			else if ( sklsum >= 200.0 )
				max = 4;
			else if ( sklsum >= 160.0 )
				max = 3;
			else
				max = 2;

			if ( taming >= 100.0 )
				max += (int)((taming - 90.0) / 10);

			if ( anlore >= 100.0 )
				max += (int)((anlore - 90.0) / 10);

			if ( vetern >= 100.0 )
				max += (int)((vetern - 90.0) / 10);

			return max;
		}

		private class StableTarget : Target
		{
			private KameronKoveAnimalTrainer m_Trainer;

			public StableTarget( KameronKoveAnimalTrainer trainer ) : base( 12, false, TargetFlags.None )
			{
				m_Trainer = trainer;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is BaseCreature )
					m_Trainer.EndStable( from, (BaseCreature)targeted );
				else if ( targeted == from )
					m_Trainer.SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn.
				else
					m_Trainer.SayTo( from, 1048053 ); // You can't stable that!
			}
		}
		
		private void CloseClaimList( Mobile from )
		{
			from.CloseGump( typeof( ClaimListGump ) );
		}

		public void BeginClaimList( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			List<BaseCreature> list = new List<BaseCreature>();

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				list.Add( pet );
			}

			if ( list.Count > 0 )
				from.SendGump( new ClaimListGump( this, from, list ) );
			else
				SayTo( from, 502671 ); // But I have no animals stabled with me at the moment!
		}

		public void EndClaimList( Mobile from, BaseCreature pet )
		{
			if ( pet == null || pet.Deleted || from.Map != this.Map || !from.Stabled.Contains( pet ) || !from.CheckAlive() )
				return;
			
			if ( !from.InRange( this, 14 ) )
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
				return;
			}

			if ( CanClaim( from, pet ) )
			{
				DoClaim( from, pet );

				from.Stabled.Remove( pet );
			}
			else
			{
				SayTo( from, 1049612, pet.Name ); // ~1_NAME~ remained in the stables because you have too many followers.
			}
		}

		public void BeginStable( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			Container bank = from.FindBankNoCreate();
			
			if ( ( from.Backpack == null || from.Backpack.GetAmount( typeof( Gold ) ) < 30 ) && ( bank == null || bank.GetAmount( typeof( Gold ) ) < 30 ) )
			{
				SayTo( from, 1042556 ); // Thou dost not have enough gold, not even in thy bank account.
			}
			else
			{
				/* I charge 30 gold per pet for a real week's stable time.
				 * I will withdraw it from thy bank account.
				 * Which animal wouldst thou like to stable here?
				 */
				from.SendLocalizedMessage(1042558);

				from.Target = new StableTarget( this );
			}
		}

		public void EndStable( Mobile from, BaseCreature pet )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			if ( pet.Body.IsHuman )
			{
				SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn.
			}
			else if ( !pet.Controlled )
			{
				SayTo( from, 1048053 ); // You can't stable that!
			}
			else if ( pet.ControlMaster != from )
			{
				SayTo( from, 1042562 ); // You do not own that pet!
			}
			else if ( pet.IsDeadPet )
			{
				SayTo( from, 1049668 ); // Living pets only, please.
			}
			else if ( pet.Summoned )
			{
				SayTo( from, 502673 ); // I can not stable summoned creatures.
			}
			else if ( (pet is PackLlama || pet is PackHorse || pet is Beetle) && (pet.Backpack != null && pet.Backpack.Items.Count > 0) )
			{
				SayTo( from, 1042563 ); // You need to unload your pet.
			}
			else if ( pet.Combatant != null && pet.InRange( pet.Combatant, 12 ) && pet.Map == pet.Combatant.Map )
			{
				SayTo( from, 1042564 ); // I'm sorry.  Your pet seems to be busy.
			}
			else if ( from.Stabled.Count >= GetMaxStabled( from ) )
			{
				SayTo( from, 1042565 ); // You have too many pets in the stables!
			}
			else
			{
				Container bank = from.FindBankNoCreate();

				if ( ( from.Backpack != null && from.Backpack.ConsumeTotal( typeof( Gold ), 30 ) ) || ( bank != null && bank.ConsumeTotal( typeof( Gold ), 30 ) ) )
				{
					pet.ControlTarget = null;
					pet.ControlOrder = OrderType.Stay;
					pet.Internalize();

					pet.SetControlMaster( null );
					pet.SummonMaster = null;

					pet.IsStabled = true;

					if ( Core.SE )	
						pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully happy

					from.Stabled.Add( pet );

					SayTo( from, Core.AOS ? 1049677 : 502679 ); // [AOS: Your pet has been stabled.] Very well, thy pet is stabled. Thou mayst recover it by saying 'claim' to me. In one real world week, I shall sell it off if it is not claimed!
				}
				else
				{
					SayTo( from, 502677 ); // But thou hast not the funds in thy bank account!
				}
			}
		}

		public void Claim( Mobile from )
		{
			Claim( from, null );
		}

		public void Claim( Mobile from, string petName )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			bool claimed = false;
			int stabled = 0;
			
			bool claimByName = ( petName != null );

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				++stabled;

				if ( claimByName && !Insensitive.Equals( pet.Name, petName ) )
					continue;

				if ( CanClaim( from, pet ) )
				{
					DoClaim( from, pet );

					from.Stabled.RemoveAt( i );
					--i;

					claimed = true;
				}
				else
				{
					SayTo( from, 1049612, pet.Name ); // ~1_NAME~ remained in the stables because you have too many followers.
				}
			}

			if ( claimed )
				SayTo( from, 1042559 ); // Here you go... and good day to you!
			else if ( stabled == 0 )
				SayTo( from, 502671 ); // But I have no animals stabled with me at the moment!
			else if ( claimByName )
				BeginClaimList( from );
		}

		public bool CanClaim( Mobile from, BaseCreature pet )
		{
			return ((from.Followers + pet.ControlSlots) <= from.FollowersMax);
		}

		private void DoClaim( Mobile from, BaseCreature pet )
		{
			pet.SetControlMaster( from );

			if ( pet.Summoned )
				pet.SummonMaster = from;

			pet.ControlTarget = from;
			pet.ControlOrder = OrderType.Follow;

			pet.MoveToWorld( from.Location, from.Map );

			pet.IsStabled = false;

			if ( Core.SE )
				pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully Happy
		}

		public override bool HandlesOnSpeech( Mobile from )
		{
			return true;
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled && e.HasKeyword( 0x0008 ) ) // *stable*
			{
				e.Handled = true;
				
				CloseClaimList( e.Mobile );				
				BeginStable( e.Mobile );
			}
			else if ( !e.Handled && e.HasKeyword( 0x0009 ) ) // *claim*
			{
				e.Handled = true;
				
				CloseClaimList( e.Mobile );
				
				int index = e.Speech.IndexOf( ' ' );

				if ( index != -1 )
					Claim( e.Mobile, e.Speech.Substring( index ).Trim() );
				else
					Claim( e.Mobile );
			}
			else
			{
				base.OnSpeech( e );
			}
		}

		public KameronKoveAnimalTrainer( Serial serial ) : base( serial )
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

	public class SBKameronKoveAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKameronKoveAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new AnimalBuyInfo( 1, typeof( Chakla ), 90, 10, 201, 2405 ) );
				Add( new AnimalBuyInfo( 1, typeof( Cinnamologus ), 50, 10, 832, 1608 ) );
				Add( new AnimalBuyInfo( 1, typeof( Dobharchu ), 100, 10, 217, 93 ) );
				Add( new AnimalBuyInfo( 1, typeof( ForestBat ), 160, 10, 317, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( SilverbackGorilla ), 100, 10, 0x1D, 1154 ) );
				Add( new AnimalBuyInfo( 1, typeof( Taniwha ), 2137, 30, 235, 93 ) );
				Add( new AnimalBuyInfo( 1, typeof( Waitoreke ), 50, 10, 0x117, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( Goat ), 60, 10, 0xD1, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Hind ), 100, 10, 0xED, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Pig ), 160, 10, 0xCB, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rabbit ), 60, 10, 205, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rat ), 50, 10, 238, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Walrus ), 241, 10, 0xDD, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 500, 15, 291, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 500, 15, 292, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Grachiosaur ), 35000, 10, 288, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( GreatHart ), 1000, 20, 0xEA, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Nephropirok ), 2000, 20, 0x112, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Shachihoko ), 3000, 20, 0x11C, 88 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
