using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting; 

namespace Server.Items
{
	public class RuneOfRegret : Item
	{
		public override string DefaultName
		{
			get { return "Rune of Regret"; }
		}

		[Constructable]
		public RuneOfRegret() : base( 0x1F14 )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public RuneOfRegret( Serial serial ) : base( serial )
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
			if ( IsChildOf( from.Backpack ) )
			{
				from.CloseGump( typeof( RuneOfRegretGump ) );
				from.SendGump( new RuneOfRegretGump( from ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
      }

	public class RuneOfRegretGump : Gump
	{
		public RuneOfRegretGump( Mobile m): base( 0, 0 )
		{
			this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddLabel(282, 151, 1153, @"Rune of Regret!");
			this.AddButton(226, 469, 247, 248, 0, GumpButtonType.Reply, 0);
			this.AddButton(351, 469, 241, 242,  1, GumpButtonType.Reply, 0);
			this.AddHtml( 157, 181, 345, 279, "This rune will revoke your murder count.<br><br><i>By using this rune, your strength, dexterity and intelligence will be decreased by a slight margin. If you use this rune while any of your stats are 50 or below you will be permanently cursed to wander the earth as a pair of running pants and revert back to level 1.</i><br><br>Are you sure you want to commit?", false, true);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			PlayerMobile player = from as PlayerMobile;

			switch( info.ButtonID )
			{
				case 0:
				{
			                Item a = from.Backpack.FindItemByType( typeof(RuneOfRegret) );
			                if ( a != null )

				        a.Delete();
					from.Kills = 0;
                                        from.SendMessage( "You have been resolved of all sin at the cost of your sanity." );

					PlayerMobile pm = from as PlayerMobile;

					if ( pm.Level > 1 && pm.Level < 10 )
                                        {
					    from.Kills = 0;
                                            from.Str -= 5;
                                            from.Dex -= 5;
                                            from.Int -= 5;
                                        }
					else if ( pm.Level > 10 && pm.Level < 30 )
                                        {
					    from.Kills = 0;
                                            from.Str -= 20;
                                            from.Dex -= 20;
                                            from.Int -= 20;
                                        }
					else if ( pm.Level > 30 && pm.Level < 60 )
                                        {
					    from.Kills = 0;
                                            from.Str -= 30;
                                            from.Dex -= 30;
                                            from.Int -= 30;
                                        }
					else if ( pm.Level > 60 && pm.Level < 101 )
                                        {
					    from.Kills = 0;
                                            from.Str -= 50;
                                            from.Dex -= 50;
                                            from.Int -= 50;
                                        }

					if ( from.RawStr <= 50 )
                                        {
                                              player.Level = 1;
                                              player.Exp = 0;
                                              player.KillExp = 0;
                                              player.LevelAt = 200;

					      from.Kills = 0;

                                              from.Title = "the Running Pants";
		                              from.EquipItem( new YoureFuckedTalisman() );

                                              from.StatCap = 500;
                                              from.SkillsCap = 30000;
                                              from.Str = 10;
                                              from.Dex = 10;
                                              from.Int = 10;

                                              from.Hunger = 0;
                                              from.Thirst = 0;

                                              from.Fame -= 50000;
                                              from.Karma -= 50000;

                                              from.FollowersMax = 100;

		                              ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		                              ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		                              ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		                              ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		                              ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		                              from.AddResistanceMod( mod1 );
		                              from.AddResistanceMod( mod2 );
		                              from.AddResistanceMod( mod3 );
		                              from.AddResistanceMod( mod4 );
		                              from.AddResistanceMod( mod5 );

                                              from.Skills.Alchemy.Base = 0;
                                              from.Skills.Anatomy.Base = 0;
                                              from.Skills.AnimalLore.Base = 0;
                                              from.Skills.AnimalTaming.Base = 0;
                                              from.Skills.Archery.Base = 0;
                                              from.Skills.ArmsLore.Base = 0;
                                              from.Skills.Begging.Base = 0;
                                              from.Skills.Blacksmith.Base = 0;
                                              from.Skills.Camping.Base = 0;
                                              from.Skills.Carpentry.Base = 0;
                                              from.Skills.Cartography.Base = 0;
                                              from.Skills.Cooking.Base = 0;
                                              from.Skills.DetectHidden.Base = 0;
                                              from.Skills.Discordance.Base = 0;
                                              from.Skills.EvalInt.Base = 0;
                                              from.Skills.Fishing.Base = 0;
                                              from.Skills.Fencing.Base = 0;
                                              from.Skills.Fletching.Base = 0;
                                              from.Skills.Focus.Base = 0;
                                              from.Skills.Forensics.Base = 0;
                                              from.Skills.Healing.Base = 0;
                                              from.Skills.Herding.Base = 0;
                                              from.Skills.Hiding.Base = 0;
                                              from.Skills.Inscribe.Base = 0;
                                              from.Skills.ItemID.Base = 0;
                                              from.Skills.Lockpicking.Base = 0;
                                              from.Skills.Lumberjacking.Base = 0;
                                              from.Skills.Macing.Base = 0;
                                              from.Skills.Magery.Base = 0;
                                              from.Skills.MagicResist.Base = 10;
                                              from.Skills.Meditation.Base = 0;
                                              from.Skills.Mining.Base = 0;
                                              from.Skills.Musicianship.Base = 0;
                                              from.Skills.Parry.Base = 0;
                                              from.Skills.Peacemaking.Base = 0;
                                              from.Skills.Poisoning.Base = 0;
                                              from.Skills.Provocation.Base = 0;
                                              from.Skills.RemoveTrap.Base = 0;
                                              from.Skills.Snooping.Base = 0;
                                              from.Skills.SpiritSpeak.Base = 0;
                                              from.Skills.Stealing.Base = 0;
                                              from.Skills.Stealth.Base = 0;
                                              from.Skills.Swords.Base = 0;
                                              from.Skills.Tactics.Base = 0;
                                              from.Skills.Tailoring.Base = 0;
                                              from.Skills.TasteID.Base = 0;
                                              from.Skills.Tinkering.Base = 0;
                                              from.Skills.Tracking.Base = 0;
                                              from.Skills.Veterinary.Base = 0;
                                              from.Skills.Wrestling.Base = 0;
                                              from.Skills.Chivalry.Base = 0;
                                              from.Skills.Necromancy.Base = 0;
                                              from.Skills.Bushido.Base = 0;
                                              from.Skills.Ninjitsu.Base = 0;
                                              from.Skills.Spellweaving.Base = 0;

                                              from.PlaySound( 0x61F ); // wilhelm scream
                                              World.Broadcast( 0x35, true, string.Format( "{0} is permanently cursed as a pair of running pants due to being a colossal scathead!", from.Name ) );
					}
					else if ( from.RawDex <= 50 )
                                        {
                                              player.Level = 1;
                                              player.Exp = 0;
                                              player.KillExp = 0;
                                              player.LevelAt = 200;

					      from.Kills = 0;

                                              from.Title = "the Running Pants";
		                              from.EquipItem( new YoureFuckedTalisman() );

                                              from.StatCap = 500;
                                              from.SkillsCap = 30000;
                                              from.Str = 10;
                                              from.Dex = 10;
                                              from.Int = 10;

                                              from.Hunger = 0;
                                              from.Thirst = 0;

                                              from.Fame -= 50000;
                                              from.Karma -= 50000;

                                              from.FollowersMax = 100;

		                              ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		                              ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		                              ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		                              ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		                              ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		                              from.AddResistanceMod( mod1 );
		                              from.AddResistanceMod( mod2 );
		                              from.AddResistanceMod( mod3 );
		                              from.AddResistanceMod( mod4 );
		                              from.AddResistanceMod( mod5 );

                                              from.Skills.Alchemy.Base = 0;
                                              from.Skills.Anatomy.Base = 0;
                                              from.Skills.AnimalLore.Base = 0;
                                              from.Skills.AnimalTaming.Base = 0;
                                              from.Skills.Archery.Base = 0;
                                              from.Skills.ArmsLore.Base = 0;
                                              from.Skills.Begging.Base = 0;
                                              from.Skills.Blacksmith.Base = 0;
                                              from.Skills.Camping.Base = 0;
                                              from.Skills.Carpentry.Base = 0;
                                              from.Skills.Cartography.Base = 0;
                                              from.Skills.Cooking.Base = 0;
                                              from.Skills.DetectHidden.Base = 0;
                                              from.Skills.Discordance.Base = 0;
                                              from.Skills.EvalInt.Base = 0;
                                              from.Skills.Fishing.Base = 0;
                                              from.Skills.Fencing.Base = 0;
                                              from.Skills.Fletching.Base = 0;
                                              from.Skills.Focus.Base = 0;
                                              from.Skills.Forensics.Base = 0;
                                              from.Skills.Healing.Base = 0;
                                              from.Skills.Herding.Base = 0;
                                              from.Skills.Hiding.Base = 0;
                                              from.Skills.Inscribe.Base = 0;
                                              from.Skills.ItemID.Base = 0;
                                              from.Skills.Lockpicking.Base = 0;
                                              from.Skills.Lumberjacking.Base = 0;
                                              from.Skills.Macing.Base = 0;
                                              from.Skills.Magery.Base = 0;
                                              from.Skills.MagicResist.Base = 10;
                                              from.Skills.Meditation.Base = 0;
                                              from.Skills.Mining.Base = 0;
                                              from.Skills.Musicianship.Base = 0;
                                              from.Skills.Parry.Base = 0;
                                              from.Skills.Peacemaking.Base = 0;
                                              from.Skills.Poisoning.Base = 0;
                                              from.Skills.Provocation.Base = 0;
                                              from.Skills.RemoveTrap.Base = 0;
                                              from.Skills.Snooping.Base = 0;
                                              from.Skills.SpiritSpeak.Base = 0;
                                              from.Skills.Stealing.Base = 0;
                                              from.Skills.Stealth.Base = 0;
                                              from.Skills.Swords.Base = 0;
                                              from.Skills.Tactics.Base = 0;
                                              from.Skills.Tailoring.Base = 0;
                                              from.Skills.TasteID.Base = 0;
                                              from.Skills.Tinkering.Base = 0;
                                              from.Skills.Tracking.Base = 0;
                                              from.Skills.Veterinary.Base = 0;
                                              from.Skills.Wrestling.Base = 0;
                                              from.Skills.Chivalry.Base = 0;
                                              from.Skills.Necromancy.Base = 0;
                                              from.Skills.Bushido.Base = 0;
                                              from.Skills.Ninjitsu.Base = 0;
                                              from.Skills.Spellweaving.Base = 0;

                                              from.PlaySound( 0x61F ); // wilhelm scream
                                              World.Broadcast( 0x35, true, string.Format( "{0} is permanently cursed as a pair of running pants due to being a colossal scathead!", from.Name ) );
					}
					else if ( from.RawInt <= 50 )
                                        {
                                              player.Level = 1;
                                              player.Exp = 0;
                                              player.KillExp = 0;
                                              player.LevelAt = 200;

					      from.Kills = 0;

                                              from.Title = "the Running Pants";
		                              from.EquipItem( new YoureFuckedTalisman() );

                                              from.StatCap = 500;
                                              from.SkillsCap = 30000;
                                              from.Str = 10;
                                              from.Dex = 10;
                                              from.Int = 10;

                                              from.Hunger = 0;
                                              from.Thirst = 0;

                                              from.Fame -= 50000;
                                              from.Karma -= 50000;

                                              from.FollowersMax = 100;

		                              ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		                              ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		                              ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		                              ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		                              ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		                              from.AddResistanceMod( mod1 );
		                              from.AddResistanceMod( mod2 );
		                              from.AddResistanceMod( mod3 );
		                              from.AddResistanceMod( mod4 );
		                              from.AddResistanceMod( mod5 );

                                              from.Skills.Alchemy.Base = 0;
                                              from.Skills.Anatomy.Base = 0;
                                              from.Skills.AnimalLore.Base = 0;
                                              from.Skills.AnimalTaming.Base = 0;
                                              from.Skills.Archery.Base = 0;
                                              from.Skills.ArmsLore.Base = 0;
                                              from.Skills.Begging.Base = 0;
                                              from.Skills.Blacksmith.Base = 0;
                                              from.Skills.Camping.Base = 0;
                                              from.Skills.Carpentry.Base = 0;
                                              from.Skills.Cartography.Base = 0;
                                              from.Skills.Cooking.Base = 0;
                                              from.Skills.DetectHidden.Base = 0;
                                              from.Skills.Discordance.Base = 0;
                                              from.Skills.EvalInt.Base = 0;
                                              from.Skills.Fishing.Base = 0;
                                              from.Skills.Fencing.Base = 0;
                                              from.Skills.Fletching.Base = 0;
                                              from.Skills.Focus.Base = 0;
                                              from.Skills.Forensics.Base = 0;
                                              from.Skills.Healing.Base = 0;
                                              from.Skills.Herding.Base = 0;
                                              from.Skills.Hiding.Base = 0;
                                              from.Skills.Inscribe.Base = 0;
                                              from.Skills.ItemID.Base = 0;
                                              from.Skills.Lockpicking.Base = 0;
                                              from.Skills.Lumberjacking.Base = 0;
                                              from.Skills.Macing.Base = 0;
                                              from.Skills.Magery.Base = 0;
                                              from.Skills.MagicResist.Base = 10;
                                              from.Skills.Meditation.Base = 0;
                                              from.Skills.Mining.Base = 0;
                                              from.Skills.Musicianship.Base = 0;
                                              from.Skills.Parry.Base = 0;
                                              from.Skills.Peacemaking.Base = 0;
                                              from.Skills.Poisoning.Base = 0;
                                              from.Skills.Provocation.Base = 0;
                                              from.Skills.RemoveTrap.Base = 0;
                                              from.Skills.Snooping.Base = 0;
                                              from.Skills.SpiritSpeak.Base = 0;
                                              from.Skills.Stealing.Base = 0;
                                              from.Skills.Stealth.Base = 0;
                                              from.Skills.Swords.Base = 0;
                                              from.Skills.Tactics.Base = 0;
                                              from.Skills.Tailoring.Base = 0;
                                              from.Skills.TasteID.Base = 0;
                                              from.Skills.Tinkering.Base = 0;
                                              from.Skills.Tracking.Base = 0;
                                              from.Skills.Veterinary.Base = 0;
                                              from.Skills.Wrestling.Base = 0;
                                              from.Skills.Chivalry.Base = 0;
                                              from.Skills.Necromancy.Base = 0;
                                              from.Skills.Bushido.Base = 0;
                                              from.Skills.Ninjitsu.Base = 0;
                                              from.Skills.Spellweaving.Base = 0;

                                              from.PlaySound( 0x61F ); // wilhelm scream
                                              World.Broadcast( 0x35, true, string.Format( "{0} is permanently cursed as a pair of running pants due to being a colossal scathead!", from.Name ) );
					}

					from.CloseGump( typeof( RuneOfRegretGump ) );

					break;
				}
				case 1:
				{
					from.SendMessage( "You decide to not to use the rune of regret. Continue on being a bastard." );
					from.CloseGump( typeof( RuneOfRegretGump ) );
					break;
				}
			}
		}
	}
}
