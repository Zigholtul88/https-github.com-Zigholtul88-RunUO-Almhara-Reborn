//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class CelesBoots: Boots
{
	public override int ArtifactRarity{ get{ return 6; } }
            
              [Constructable]
              public CelesBoots()
{

                          Weight = 7;
                          Name = "[FF6] Celes' Boots";
                          Hue = 2041;
              
              Attributes.BonusDex = 15;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 15;
              Attributes.DefendChance = 15;
              Attributes.LowerManaCost = 20;
              Attributes.Luck = 50;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 10;
              Attributes.RegenHits = 2;
              Attributes.WeaponDamage = 5;
              Attributes.BonusStr = 25;
                  }
              public CelesBoots( Serial serial ) : base( serial )
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
