using System;
using Server.Mobiles;

namespace Server.Items
{
	public class BaseShield_ItemOfLight : BaseShield
        {
		private Item mLight;
		bool mIsLit = false;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Item Link
		{ 
			get { return mLight; } 
			set { mLight = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsLit 
		{ 
			get { return mIsLit; } 
			set { mIsLit = value; }
		}
		
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		
		
		[Constructable]
                public BaseShield_ItemOfLight() : base(0x1B78)
                {
			Layer = Layer.TwoHanded;
                }
	
		public override void OnDoubleClick( Mobile from ) 
		{
			if ( from == null ) 
                        { 
                                return; 
                        }
			
			if ( Parent != from ) 
                        { 
				from.SendMessage("You must equip the item for it to light your way."); 
				return;
			}
			
			if ( from.FindItemOnLayer(Layer.Unused_xF) != mLight ) 
                        {
				from.SendMessage("You cannot do that at this time.");
				return;
			}
			
			if ( IsLit == false & from.FindItemOnLayer(Layer.Unused_xF) == null ) 
                        {
				IsLit = true;
				CreateLight(from);
			}
			else
                        { 
                                Nullify(); 
                        }
		}
		
		public void Nullify()
		{
			if ( mLight != null ) 
                        {
				mLight.Delete(); 
				mLight = null;
				IsLit = false;
			}
		}
		
		public bool OnEquip( Item item, Mobile parent )
		{
			if ( this.mLight != null && !mLight.Deleted ) 
                        {
				mLight.Delete();
				CreateLight(parent);
				
			}
			return true;
		}
	
		public override bool OnDragLift( Mobile from )
		{
			if ( mLight != null ) 
                        {
				mLight.Delete(); 
				mLight = null; 
				IsLit = false;
			}
			return true;
		}


		public void CreateLight( Mobile from )
		{
			WearableLight light = new WearableLight();
			mLight = light;
			from.EquipItem( mLight );
		}
		
		public override void OnAfterDelete() 
		{
			base.OnAfterDelete();
			if ( mLight != null )
                        { 
				mLight.Delete(); 
			}
		}
	
                public BaseShield_ItemOfLight(Serial serial) : base(serial)
                { 
                }

                public override void Serialize(GenericWriter writer)
                {
                        base.Serialize(writer);
                        writer.Write((int)0);
			
			writer.Write( ( Item )mLight );
			writer.Write( ( bool )IsLit );
                }

                public override void Deserialize(GenericReader reader)
                {
                        base.Deserialize(reader);
                        int version = reader.ReadInt();
			
			mLight = ( WearableLight )reader.ReadItem( );
			IsLit = (bool) reader.ReadBool();
                }
        }
}