using System;
using Server;

namespace Server.Items
{
        public class LuckyEarrings : GoldEarrings, ITokunoDyable
        {
                [Constructable]
                public LuckyEarrings()
                {
                        Name = "Lucky Earrings";
                        Hue = 1174;            
                        Attributes.Luck = 200;
                        Attributes.AttackChance = 5;
                        Attributes.DefendChance = 5;
                        Attributes.WeaponSpeed = 5;
                 }

                 public LuckyEarrings (Serial serial) : base( serial )
                 {
                 }

                 public override void Serialize( GenericWriter writer )
                 {
                         base.Serialize( writer );
                         writer.Write( (int) 0 );
                 }

                 public override void Deserialize(GenericReader reader)
                 {
                         base.Deserialize( reader );
                         int version = reader.ReadInt();
                 }
        } 
}
