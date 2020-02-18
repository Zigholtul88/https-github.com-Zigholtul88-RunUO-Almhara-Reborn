using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ElmhavenFlowerArranger2Gump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ElmhavenFlowerArranger2Gump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenFlowerArranger2Gump_OnCommand ) ); 
      } 

      private static void ElmhavenFlowerArranger2Gump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ElmhavenFlowerArranger2Gump( e.Mobile ) ); 
      } 

      public ElmhavenFlowerArranger2Gump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Damn it I forgot to mention that you <BR>" +
"<BASEFONT COLOR=YELLOW>will also be needing a seed. The best <BR>" +
"<BASEFONT COLOR=YELLOW>advice I can give you is to hunt down <BR>" +
"<BASEFONT COLOR=YELLOW>the Dark Roses that populate the Bog of<BR>" +
"<BASEFONT COLOR=YELLOW>Toads located far south of this <BR>" +
"<BASEFONT COLOR=YELLOW>establishment, right next to the Oboru <BR>" +
"<BASEFONT COLOR=YELLOW>Jungle. I wouldn't mess with the frogs <BR>" +
"<BASEFONT COLOR=YELLOW>considering they are extremely toxic in<BR>" +
"<BASEFONT COLOR=YELLOW>nature so be careful.<BR>" +
"</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               break; 
            } 

         }
      }
   }
}