using System;
using System.Collections.Generic;

namespace Server.Engines.BulkOrders
{
    [TypeAlias( "Scripts.Engines.BulkOrders.LargeInscriptionBOD" )]
    public class LargeInscriptionBOD : LargeBOD
    {
        [Constructable]
        public LargeInscriptionBOD()
        {
            LargeBulkEntry[] entries;

            switch (Utility.Random(10))
            {
                default:
                case 0:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeBooks);
                    break;
                case 1:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle1);
                    break;
                case 2:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle1and2);
                    break;
                case 3:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle4);
                    break;
                case 4:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle5);
                    break;
                case 5:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle7);
                    break;
                case 6:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeCircle8);
                    break;
                case 7:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeNecromancy1);
                    break;
                case 8:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeNecromancy2);
                    break;
                case 9:
                    entries = LargeBulkEntry.ConvertEntries(this, LargeBulkEntry.LargeNecromancy3);
                    break;
            }

            int amountMax = Utility.RandomList(10, 15, 20, 20);

            this.Hue = 2598;
            this.AmountMax = amountMax;
            this.Entries = entries;
        }

        public LargeInscriptionBOD(int amountMax, bool reqExceptional, BulkMaterialType mat, LargeBulkEntry[] entries)
        {
            this.Hue = 2598;
            this.AmountMax = amountMax;
            this.Entries = entries;
            this.RequireExceptional = reqExceptional;
            this.Material = mat;
        }

        public LargeInscriptionBOD(Serial serial)
            : base(serial)
        {
        }

        public override int ComputeFame()
        {
            return InscriptionRewardCalculator.Instance.ComputeFame(this);
        }

        public override int ComputeGold()
        {
            return InscriptionRewardCalculator.Instance.ComputeGold(this);
        }

        public override List<Item> ComputeRewards(bool full)
        {
            List<Item> list = new List<Item>();

            RewardGroup rewardGroup = InscriptionRewardCalculator.Instance.LookupRewards(InscriptionRewardCalculator.Instance.ComputePoints(this));

            if (rewardGroup != null)
            {
                if (full)
                {
                    for (int i = 0; i < rewardGroup.Items.Length; ++i)
                    {
                        Item item = rewardGroup.Items[i].Construct();

                        if (item != null)
                            list.Add(item);
                    }
                }
                else
                {
                    RewardItem rewardItem = rewardGroup.AcquireItem();

                    if (rewardItem != null)
                    {
                        Item item = rewardItem.Construct();

                        if (item != null)
                            list.Add(item);
                    }
                }
            }

            return list;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}