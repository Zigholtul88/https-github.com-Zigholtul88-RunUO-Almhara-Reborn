  //----------------------------------------------------------------------------------//
 // Created by Vano. Email: vano2006uo@mail.ru      //
//---------------------------------------------------------------------------------//
using System;
using Server;
using System.Collections;

namespace Server.Items
{
	public class ForceArrow : WeaponAbility
	{
		public ForceArrow()
		{
		}

		public override int BaseStam { get { return 20; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if( !Validate( attacker ) || !CheckStam( attacker, true ) )
				return;

			ClearCurrentAbility( attacker );


			attacker.SendMessage( "Enemie are temporarily easier to hit" ); 
			defender.SendMessage( "You are temporarily easier to hit" );

			if (Utility.RandomDouble() >= attacker.Skills[SkillName.Anatomy].Value/600)
			{
			defender.Warmode = false;
			attacker.SendMessage( "Mobile forget who are attacking." ); 
			}
			DoLowerDefense( attacker, defender );
		}
			public virtual void DoLowerDefense( Mobile from, Mobile defender )
		{
			if ( HitLower.ApplyDefense( defender ) )
			{
				defender.PlaySound( 0x28E );
				Effects.SendTargetEffect( defender, 0x37BE, 1, 4, 0x23, 3 );
			}
		}
	}
}
