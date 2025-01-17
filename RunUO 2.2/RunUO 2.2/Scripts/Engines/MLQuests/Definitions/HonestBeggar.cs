using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Definitions
{
	#region Quests

	public class HonestBeggar : MLQuest
	{
		public override Type NextQuest { get { return typeof( ReginasThanks ); } }

		public HonestBeggar()
		{
			Activated = true;
			Title = 1075392; // Honest Beggar
			Description = "Beg pardon, sir. I mean, madam. Uh, can I ask a favor of you? I found this jeweled ring.  Most people would sell it and keep the money, but not me. I ain't never stole nothing, and I ain't about to start. I tried to take it over to Red Dagger Keep, figgerin' it must belong to some highborn lady, but the guards threw me out. You look like they might let you pass. Will you take the ring over there and see if you can find the owner?";
			RefusalMessage = "I see. Too good to help an honest beggar like me, eh?";
			InProgressMessage = "A jewel like this must be worth a lot, so it must belong to some noble or another. I would show it around the establishment. Someone�s bound to recognize it.";
			CompletionMessage = "Didst thou find my ring? I thank thee very much! It is an old ring, and a gift from my husband. I was most distraught when I realized it was missing.";
			CompletionNotice = CompletionNoticeShort;

			Objectives.Add( new DeliverObjective( typeof( ReginasRing ), 1, "Regina's Ring", typeof( Regina ) ) );
		}
	}

	public class ReginasThanks : MLQuest
	{
		public override bool IsChainTriggered { get { return true; } }

		public ReginasThanks()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Regina�s Thanks";
			Description = "What�s that you say? It was a humble beggar that found my ring? Such honesty must be rewarded. Here, take this packet and return it to him, and I will be in your debt.";
			RefusalMessage = "Hmph. Very well. What did you say his name was?";
			InProgressMessage = "Take the packet and return it to the beggar who found my ring.";
			CompletionMessage = "What? For me? Let me see . . . these sapphire earrings are for you, it says. Oh, she wants to offer me a job! This is the most wonderful thing that ever happened to me!";
			CompletionNotice = CompletionNoticeShort;

			Objectives.Add( new DeliverObjective( typeof( ReginasLetter ), 1, "Regina's Letter", typeof( Evan ) ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1000 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
			Rewards.Add( ItemReward.MediumBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	public class Evan : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Evan(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Evan - (Honest Beggar)";
			Title = "the Beggar";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Backpack() );
			AddItem( new Doublet() );
			AddItem( new ShortPants( 0x755 ) );
		}

		public Evan( Serial serial ): base( serial )
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

	public class Regina : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }

		[Constructable]
		public Regina(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Regina";
			Title = "the Noble";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			AddItem( new Backpack() );
			AddItem( new GildedDress() );
			AddItem( new Boots() );
		}

		public Regina( Serial serial ): base( serial )
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

	#endregion
}
