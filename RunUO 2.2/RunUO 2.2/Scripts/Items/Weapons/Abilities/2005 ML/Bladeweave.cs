  //----------------------------------------------------------------------------------//
 // Created by Vano. Email: vano2006uo@mail.ru      //
//---------------------------------------------------------------------------------//
using System;
using Server;
using System.Collections;
using Server.Items;

namespace Server.Items
{
	public class Bladeweave : WeaponAbility
	{

		public Bladeweave()
		{
		}

		public override int BaseStam { get { return 30; } }

		public override bool OnBeforeDamage( Mobile attacker, Mobile defender )
		{
			if ( !Validate( attacker ) || !CheckStam( attacker, true ) )
				return false;

			ClearCurrentAbility( attacker );

			attacker.SendMessage( "You become one with you weapon, allowing it to guide you hand. The effects of this attack are unpredictable, but effective." );
			defender.SendMessage( "Your enemy becomes one with their weapon and the effects of his attack are unpredictable" );

				attacker.PlaySound( 0x20C );
				attacker.PlaySound( 0x56 );
				attacker.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );

				IEntity from = new Entity( Serial.Zero, new Point3D( attacker.X, attacker.Y, attacker.Z ), attacker.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( attacker.X, attacker.Y, attacker.Z + 50 ), attacker.Map );
				Effects.SendMovingParticles( from, to, 0xF5F, 1, 0, false, false, 33, 3, 9501, 1, 0, EffectLayer.Head, 0x100 );

			int damage = 10; 

			damage += Math.Min( 5, (int)(Math.Abs( attacker.Skills[SkillName.Anatomy].Value + attacker.Skills[SkillName.ArmsLore].Value ) / 8));

			defender.Damage( damage, attacker );

			return true;
		}
	}
}
