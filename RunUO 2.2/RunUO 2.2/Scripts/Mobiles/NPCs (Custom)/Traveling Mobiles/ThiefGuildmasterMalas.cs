using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    public class ThiefGuildmasterMalas : BaseGuildmaster
    {

        Point3D[] MoveLocations =
        {
            new Point3D( 1148, 1099, 30 ),//Hammerhill [John Carpenter's Workshop]
            new Point3D( 1213, 1044, 10 ),//Hammerhill [Seven Deadly Sins Tavern]
            new Point3D( 740, 470, 1 ),//Elmhaven [Docks]
            new Point3D( 751, 581, 0 ),//Elmhaven [Firefly Lounge]
            new Point3D( 500, 677, 52 ),//Elandrim Nur Shaz
            new Point3D( 727, 1213, 20 ),//Old Plunderer's Haven
            new Point3D( 1737, 447, 45 ),//Coven's Landing [Maidens Selections]
            new Point3D( 1844, 417, 35 ),//Coven's Landing [The Winchester]
            new Point3D( 350, 1917, 30 ),//Guardians Horizon [Bank]
            new Point3D( 315, 1889, 25 ),//Guardians Horizon [The Slam Shuffle]
            new Point3D( 246, 1746, 20 ),//Red Dagger Keep [Bank]
            new Point3D( 195, 1737, 35 ),//Red Dagger Keep [Farm]
            new Point3D( 265, 1699, 22 ) //Red Dagger Keep [Tavern]
        };

        private MoveTimer m_Timer;

        [Constructable]
        public ThiefGuildmasterMalas(): base("thief")
        {
            this.SetSkill(SkillName.DetectHidden, 75.0, 98.0);
            this.SetSkill(SkillName.Hiding, 65.0, 88.0);
            this.SetSkill(SkillName.Lockpicking, 85.0, 100.0);
            this.SetSkill(SkillName.Snooping, 90.0, 100.0);
            this.SetSkill(SkillName.Poisoning, 60.0, 83.0);
            this.SetSkill(SkillName.Stealing, 90.0, 100.0);
            this.SetSkill(SkillName.Fencing, 75.0, 98.0);
            this.SetSkill(SkillName.Stealth, 85.0, 100.0);
            this.SetSkill(SkillName.RemoveTrap, 85.0, 100.0);

            m_Timer = new MoveTimer( this );
            ChangeLocation();
        }

        public void ChangeLocation()
        {
            this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Malas );
            this.Hidden = true; //Arrives Hidden
        }

        public ThiefGuildmasterMalas(Serial serial): base(serial)
        {
        }

        public override NpcGuild NpcGuild
        {
            get
            {
                return NpcGuild.ThievesGuild;
            }
        }
        public override TimeSpan JoinAge
        {
            get
            {
                return TimeSpan.FromDays(7.0);
            }
        }
        public override void InitOutfit()
        {
            base.InitOutfit();

            if (Utility.RandomBool())
                this.AddItem(new Server.Items.Kryss());
            else
                this.AddItem(new Server.Items.Dagger());
        }

        public override bool CheckCustomReqs(PlayerMobile pm)
        {
            if (pm.Young)
            {
                this.SayTo(pm, 502089); // You cannot be a member of the Thieves' Guild while you are Young.
                return false;
            }
            else if (pm.Kills > 0)
            {
                this.SayTo(pm, 501050); // This guild is for cunning thieves, not oafish cutthroats.
                return false;
            }
            else if (pm.Skills[SkillName.Stealing].Base < 60.0)
            {
                this.SayTo(pm, 501051); // You must be at least a journeyman pickpocket to join this elite organization.
                return false;
            }

            return true;
        }

        public override void SayWelcomeTo(Mobile m)
        {
            this.SayTo(m, 1008053); // Welcome to the guild! Stay to the shadows, friend.
        }

        public override bool HandlesOnSpeech(Mobile from)
        {
            if (from.InRange(this.Location, 2))
                return true;

            return base.HandlesOnSpeech(from);
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!e.Handled && from is PlayerMobile && from.InRange(this.Location, 2) && e.HasKeyword(0x1F)) // *disguise*
            {
                PlayerMobile pm = (PlayerMobile)from;

                if (pm.NpcGuild == NpcGuild.ThievesGuild)
                    this.SayTo(from, 501839); // That particular item costs 700 gold pieces.
                else
                    this.SayTo(from, 501838); // I don't know what you're talking about.

                e.Handled = true;
            }

            base.OnSpeech(e);
        }

        public override bool OnGoldGiven(Mobile from, Gold dropped)
        {
            if (from is PlayerMobile && dropped.Amount == 700)
            {
                PlayerMobile pm = (PlayerMobile)from;

                if (pm.NpcGuild == NpcGuild.ThievesGuild)
                {
                    from.AddToBackpack(new DisguiseKit());

                    dropped.Delete();
                    return true;
                }
            }

            return base.OnGoldGiven(from, dropped);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_Timer = new MoveTimer(this);
        }

        private class MoveTimer : Timer
        {
            private ThiefGuildmasterMalas m_Owner;

            public MoveTimer(ThiefGuildmasterMalas owner)
                : base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
            {
                m_Owner = owner;
                TimerThread.PriorityChange(this, 7);
            }

            protected override void OnTick()
            {
                if (m_Owner == null)
                {
                    Stop();
                    return;
                }
                else if (m_Owner.Hits == m_Owner.HitsMax) // IE not in combat at all
                {
                    m_Owner.ChangeLocation();
                }
            }
        }
    }
}