using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.PartySystem;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	public class TreasureMapChest : LockableContainer
	{
		public override int LabelNumber{ get{ return 3000541; } }

		public static Type[] Artifacts { get { return m_Artifacts; } }

		private static Type[] m_Artifacts = new Type[]
		{
			typeof( CandelabraOfSouls ), typeof( GoldBricks ), typeof( PhillipsWoodenSteed ),
			typeof( ArcticDeathDealer ), typeof( BlazeOfDeath ), typeof( BurglarsBandana ),
			typeof( CavortingClub ), typeof( DreadPirateHat ),
			typeof( EnchantedTitanLegBone ), typeof( GwennosHarp ), typeof( IolosLute ),
			typeof( LunaLance ), typeof( NightsKiss ), typeof( NoxRangersHeavyCrossbow ),
			typeof( PolarBearMask ), typeof( VioletCourage ), typeof( HeartOfTheLion ),
			typeof( ColdBlood ), typeof( AlchemistsBauble )
		};

		private int m_Level;
		private DateTime m_DeleteTime;
		private Timer m_Timer;
		private Mobile m_Owner;
		private bool m_Temporary;

		private List<Mobile> m_Guardians;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level{ get{ return m_Level; } set{ m_Level = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner{ get{ return m_Owner; } set{ m_Owner = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime DeleteTime{ get{ return m_DeleteTime; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Temporary{ get{ return m_Temporary; } set{ m_Temporary = value; } }

		public List<Mobile> Guardians { get { return m_Guardians; } }

		[Constructable]
		public TreasureMapChest( int level ) : this( null, level, false )
		{
		}

		public TreasureMapChest( Mobile owner, int level, bool temporary ) : base( 0xE40 )
		{
			m_Owner = owner;
			m_Level = level;
			m_DeleteTime = DateTime.Now + TimeSpan.FromHours( 3.0 );

			m_Temporary = temporary;
			m_Guardians = new List<Mobile>();

			m_Timer = new DeleteTimer( this, m_DeleteTime );
			m_Timer.Start();

			Fill( this, level );
		}

        private static void GetRandomAOSStats(int lvl, out int attributeCount, out int min, out int max)
        {
            int rnd = Utility.Random(15);

            if (rnd == 0)
            {
                attributeCount = Utility.RandomMinMax(5, 6);
                min = 40+(lvl*5); max = 100;
            }
            if (rnd <= 1)
            {
                attributeCount = Utility.RandomMinMax(4, 6);
                min = 25+(lvl*5); max = 100;
            }
            else if (rnd <= 4)
            {
                attributeCount = Utility.RandomMinMax(3, 5);
                min = 15+(lvl*5); max = 100;
            }
            else if (rnd <= 7)
            {
                attributeCount = Utility.RandomMinMax(2, 4);
                min = 10+(lvl*5); max = 100;
            }
            else if (rnd <= 11)
            {
                attributeCount = Utility.RandomMinMax(2, 3);
                min = 10+(lvl*5); max = 100;
            }
            else
            {
                attributeCount = Utility.RandomMinMax(1, 3);
                min = 10+(lvl*4); max = 100;
            }
        }

        public static void Fill(LockableContainer cont, int level)
        {
            bool isFelucca = (cont.Map == Map.Felucca);
            bool inTokuno = (cont.Map == Map.Tokuno);
            bool SoS = false;

            if (cont.IsShipwreckedItem == true) { SoS = true; }

            cont.Movable = false;
            cont.Locked = true;
            int numberItems;

            if (level == 0)
            {
                cont.LockLevel = 0; // Can't be unlocked

                cont.DropItem(new Gold(Utility.RandomMinMax(500, 1000)));

                if (Utility.RandomDouble() < 0.75)
                    cont.DropItem(new TreasureMap(0, Map.Trammel));
            }
            else
            {
                cont.TrapType = TrapType.ExplosionTrap;
                cont.TrapPower = level * 25;
                cont.TrapLevel = level;

                // = Chest Lock Levels (~40% to open at cont.RequiredSkill / 100% at cont.MaxLockLevel)
                switch (level)
                {
                    case 1: cont.RequiredSkill = 5; cont.LockLevel = -25; cont.MaxLockLevel = 55 ; break;
                    case 2: cont.RequiredSkill = 45; cont.LockLevel = 25; cont.MaxLockLevel = 75; break;
                    case 3: cont.RequiredSkill = 65; cont.LockLevel = 45; cont.MaxLockLevel = 95; break;
                    case 4: cont.RequiredSkill = 75; cont.LockLevel = 55; cont.MaxLockLevel = 105; break;
                    case 5: cont.RequiredSkill = 75; cont.LockLevel = 55; cont.MaxLockLevel = 105; break;
                    case 6: cont.RequiredSkill = 80; cont.LockLevel = 60; cont.MaxLockLevel = 110; break;
                    case 7: cont.RequiredSkill = 80; cont.LockLevel = 60; cont.MaxLockLevel = 110; break;
                }

                // = GOLD PIECES
                cont.DropItem(new Gold(level * 5000));

                // = TREASURE MAP or MiB
                if (!SoS)
                {
                    if(Utility.RandomDouble() < 0.2)
                        cont.DropItem(new TreasureMap(level, MapItem.GetRandomFacet()));
                    else if ((level < 7) && (Utility.RandomDouble() < 0.025))
                        cont.DropItem(new TreasureMap(level + 1, MapItem.GetRandomFacet()));
                    else if (Utility.RandomDouble() > 0.8)
                    {
                        if (Utility.RandomDouble() > 0.5)
                            cont.DropItem(new MessageInABottle(Map.Felucca));
                        else
                            cont.DropItem(new MessageInABottle(Map.Trammel));
                    }
                }
                else if (!SoS)
                {
                    int soslvl = Utility.Random(level) + 1;

                    if (Utility.RandomDouble() < 0.2)
                        cont.DropItem(new TreasureMap(soslvl, MapItem.GetRandomFacet()));
                }

                // = LEVEL 8 ARCANE SCROLLS
                for (int i = 0; i < level; ++i)
                {
                    cont.DropItem(Loot.RandomScroll(57, 64, SpellbookType.Regular));
                }

                // = MAGIC ITEMS
                Item item;

                numberItems = 24 + (level * 8);
                for (int i = 0; i < numberItems; ++i)
                {
                    if (Core.AOS)
                        item = Loot.RandomArmorOrShieldOrWeaponOrJewelry(inTokuno);
                    else
                        item = Loot.RandomArmorOrShieldOrWeapon(inTokuno);

                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;

                        if (Core.AOS)
                        {
                            int attributeCount;
                            int min, max;

                            GetRandomAOSStats(level, out attributeCount, out min, out max);

                            BaseRunicTool.ApplyAttributesTo(weapon, attributeCount, min, max);
                        }
                        else
                        {
                            weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(6);
                            weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(6);
                            weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(6);
                        }

                        cont.DropItem(item);
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;

                        if (Core.AOS)
                        {
                            int attributeCount;
                            int min, max;

                            GetRandomAOSStats(level, out attributeCount, out min, out max);

                            BaseRunicTool.ApplyAttributesTo(armor, attributeCount, min, max);
                        }
                        else
                        {
                            armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(6);
                            armor.Durability = (ArmorDurabilityLevel)Utility.Random(6);
                        }

                        cont.DropItem(item);
                    }
                    else if (item is BaseHat)
                    {
                        BaseHat hat = (BaseHat)item;

                        if (Core.AOS)
                        {
                            int attributeCount;
                            int min, max;

                            GetRandomAOSStats(level, out attributeCount, out min, out  max);

                            BaseRunicTool.ApplyAttributesTo(hat, attributeCount, min, max);
                        }

                        cont.DropItem(item);
                    }
                    else if (item is BaseJewel)
                    {
                        int attributeCount;
                        int min, max;

                        GetRandomAOSStats(level, out attributeCount, out min, out max);

                        BaseRunicTool.ApplyAttributesTo((BaseJewel)item, attributeCount, min, max);

                        cont.DropItem(item);
                    }
                }
            }

            // = REAGENTS
            int reagents;
            if (level == 0)
                reagents = 10;
            else
                reagents = 3 + level;

            for (int i = 0; i < reagents; i++)
            {
                Item itr = Loot.RandomPossibleReagent();
                itr.Amount = Utility.RandomMinMax(40, 60);
                cont.DropItem(itr);
            }
            // = STACK OF GEMS
            int gems;
            if (level == 0)
                gems = 3;
            else
                gems = 1 + level * 3;

            Item itg = new Citrine();
            int rndG = Utility.Random(9) + 1;
            if (rndG == 1) { itg = new Amber(gems); }
            if (rndG == 2) { itg = new Amethyst(gems); }
            if (rndG == 3) { itg = new Citrine(gems); }
            if (rndG == 4) { itg = new Diamond(gems); }
            if (rndG == 5) { itg = new Emerald(gems); }
            if (rndG == 6) { itg = new Ruby(gems); }
            if (rndG == 7) { itg = new Sapphire(gems); }
            if (rndG == 8) { itg = new StarSapphire(gems); }
            if (rndG == 9) { itg = new Tourmaline(gems); }
            cont.DropItem(itg);

            // = SCROLL OF ALACRITY or POWERSCROLL
            if (level > 1)
            {
                if (Utility.RandomDouble() < (0.02 + (level / 200)))
                {
                    SkillName WhatS = (SkillName)Utility.Random(SkillInfo.Table.Length);
                    cont.DropItem(PowerScroll.CreateRandomNoCraft(5, 5));
                }
                else if (Utility.RandomDouble() < 0.075)
                {
                    SkillName WhatS = (SkillName)Utility.Random(SkillInfo.Table.Length);
                    cont.DropItem(new ScrollofAlacrity(WhatS));
                }
            }

            // = SCROLL OF TRANCENDENCE
            if ( level >= 4 && isFelucca && Utility.RandomDouble() > 0.9 )
                cont.DropItem(ScrollofTranscendence.CreateRandom(level, level * 5));

            // = CREEPING VINES
            if (!SoS && Utility.RandomDouble() < 0.075)
                cont.DropItem(new CreepingVines());
            
            // = ILSHENAR LESSER ARTIFACT
            if (level >= 6 && Core.AOS)
                cont.DropItem((Item)Activator.CreateInstance(m_Artifacts[Utility.Random(m_Artifacts.Length)]));

            // = SKELETON KEY
            if (level < 7)
            {
                if (!SoS && Utility.RandomDouble() > (0.92 - (level / 100)))
                    cont.DropItem(new SFSkeletonKey());
            }
            // = [LVL 7] = MASTER SKELETON KEY 
            if (level == 7)
            {
                if (Utility.RandomDouble() < 0.10)
                    cont.DropItem(new SFMasterSkeletonKey());         
            }
        }
	
		public override bool CheckLocked( Mobile from )
		{
			if ( !this.Locked )
				return false;

			if ( this.Level == 0 && from.AccessLevel < AccessLevel.GameMaster )
			{
				foreach ( Mobile m in this.Guardians )
				{
					if ( m.Alive )
					{
						from.SendLocalizedMessage( 1046448 ); // You must first kill the guardians before you may open this chest.
						return true;
					}
				}

				LockPick( from );
				return false;
			}
			else
			{
				return base.CheckLocked( from );
			}
		}

		private List<Item> m_Lifted = new List<Item>();

		private bool CheckLoot( Mobile m, bool criminalAction )
		{
			if ( m_Temporary )
				return false;

			if ( m.AccessLevel >= AccessLevel.GameMaster || m_Owner == null || m == m_Owner )
				return true;

			Party p = Party.Get( m_Owner );

			if ( p != null && p.Contains( m ) )
				return true;

			Map map = this.Map;

			if ( map != null && (map.Rules & MapRules.HarmfulRestrictions) == 0 )
			{
				if ( criminalAction )
					m.CriminalAction( true );
				else
					m.SendLocalizedMessage( 1010630 ); // Taking someone else's treasure is a criminal offense!

				return true;
			}

			m.SendLocalizedMessage( 1010631 ); // You did not discover this chest!
			return false;
		}

		public override bool IsDecoContainer
		{
			get{ return false; }
		}

		public override bool CheckItemUse( Mobile from, Item item )
		{
			return CheckLoot( from, item != this ) && base.CheckItemUse( from, item );
		}

		public override bool CheckLift( Mobile from, Item item, ref LRReason reject )
		{
			return CheckLoot( from, true ) && base.CheckLift( from, item, ref reject );
		}

		public override void OnItemLifted( Mobile from, Item item )
		{
			bool notYetLifted = !m_Lifted.Contains( item );

			from.RevealingAction();

			if ( notYetLifted )
			{
				m_Lifted.Add( item );

				if ( 0.1 >= Utility.RandomDouble() ) // 10% chance to spawn a new monster
					TreasureMap.Spawn( m_Level, GetWorldLocation(), Map, from, false );
			}

			base.OnItemLifted( from, item );
		}

		public override bool CheckHold( Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight )
		{
			if ( m.AccessLevel < AccessLevel.GameMaster )
			{
				m.SendLocalizedMessage( 1048122, "", 0x8A5 ); // The chest refuses to be filled with treasure again.
				return false;
			}

			return base.CheckHold( m, item, message, checkItems, plusItems, plusWeight );
		}

		public TreasureMapChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

			writer.Write( m_Guardians, true );
			writer.Write( (bool) m_Temporary );

			writer.Write( m_Owner );

			writer.Write( (int) m_Level );
			writer.WriteDeltaTime( m_DeleteTime );
			writer.Write( m_Lifted, true );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					m_Guardians = reader.ReadStrongMobileList();
					m_Temporary = reader.ReadBool();

					goto case 1;
				}
				case 1:
				{
					m_Owner = reader.ReadMobile();

					goto case 0;
				}
				case 0:
				{
					m_Level = reader.ReadInt();
					m_DeleteTime = reader.ReadDeltaTime();
					m_Lifted = reader.ReadStrongItemList();

					if ( version < 2 )
						m_Guardians = new List<Mobile>();

					break;
				}
			}

			if ( !m_Temporary )
			{
				m_Timer = new DeleteTimer( this, m_DeleteTime );
				m_Timer.Start();
			}
			else
			{
				Delete();
			}
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;

			base.OnAfterDelete();
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive )
				list.Add( new RemoveEntry( from, this ) );
		}

		public void BeginRemove( Mobile from )
		{
			if ( !from.Alive )
				return;

			from.CloseGump( typeof( RemoveGump ) );
			from.SendGump( new RemoveGump( from, this ) );
		}

		public void EndRemove( Mobile from )
		{
			if ( Deleted || from != m_Owner || !from.InRange( GetWorldLocation(), 3 ) )
				return;

			from.SendLocalizedMessage( 1048124, "", 0x8A5 ); // The old, rusted chest crumbles when you hit it.
			this.Delete();
		}

		private class RemoveGump : Gump
		{
			private Mobile m_From;
			private TreasureMapChest m_Chest;

			public RemoveGump( Mobile from, TreasureMapChest chest ) : base( 15, 15 )
			{
				m_From = from;
				m_Chest = chest;

				Closable = false;
				Disposable = false;

				AddPage( 0 );

				AddBackground( 30, 0, 240, 240, 2620 );

				AddHtmlLocalized( 45, 15, 200, 80, 1048125, 0xFFFFFF, false, false ); // When this treasure chest is removed, any items still inside of it will be lost.
				AddHtmlLocalized( 45, 95, 200, 60, 1048126, 0xFFFFFF, false, false ); // Are you certain you're ready to remove this chest?

				AddButton( 40, 153, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 75, 155, 180, 40, 1048127, 0xFFFFFF, false, false ); // Remove the Treasure Chest

				AddButton( 40, 195, 4005, 4007, 2, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 75, 197, 180, 35, 1006045, 0xFFFFFF, false, false ); // Cancel
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( info.ButtonID == 1 )
					m_Chest.EndRemove( m_From );
			}
		}

		private class RemoveEntry : ContextMenuEntry
		{
			private Mobile m_From;
			private TreasureMapChest m_Chest;

			public RemoveEntry( Mobile from, TreasureMapChest chest ) : base( 6149, 3 )
			{
				m_From = from;
				m_Chest = chest;

				Enabled = ( from == chest.Owner );
			}

			public override void OnClick()
			{
				if ( m_Chest.Deleted || m_From != m_Chest.Owner || !m_From.CheckAlive() )
					return;

				m_Chest.BeginRemove( m_From );
			}
		}

		private class DeleteTimer : Timer
		{
			private Item m_Item;

			public DeleteTimer( Item item, DateTime time ) : base( time - DateTime.Now )
			{
				m_Item = item;
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}
