using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bbuu20_s_Recoil_Handler_V2
{
    class RecoilHandler
    {
        public static byte triggerKey = 0x22;
        public static double sensitivity = 0.40;
        public static double fov = 90.0;
        public static double fireRateMultiplier = 1.0;
        public static double recoilMultiplier = 1.0;
        public static void Run()
        {
            while (true)
            {
                for (int bulletCount = 0; InputHandler.IsKeyDown(Keys.LButton) && InputHandler.IsKeyDown(Keys.RButton); bulletCount++)
                {
                    if (InputHandler.IsKeyDown(Keys.LControlKey)) //if the player is crouching
                    {
                        switch (GUI.selectedWeapon)
                        {
                            case 0: //nailgun
                                FireSemi((int)(14 / sensitivity), 8, 145, true);
                                break;
                            case 1: //rev
                                FireSemi((int)(12.5 / sensitivity), 8, 170, true);
                                break;
                            case 2: //python
                                FireSemi((int)(37.5 / sensitivity), 8, 145, true);
                                break;
                            case 3: //p250
                                FireSemi((int)(19 / sensitivity), 8, 145, true);
                                break;
                            case 4: //m92
                                FireSemi((int)(19 / sensitivity), 8, 145, true);
                                break;
                            case 5: //custom
                                Fire(RecoilTables.customTable, bulletCount, 4, 105);
                                break;
                            case 6: //thompson
                                Fire(RecoilTables.thompsonTable, bulletCount, 4, 128);
                                break;
                            case 7: //mp5
                                Fire(RecoilTables.mp5Table, bulletCount, 4, 105);
                                break;
                            case 8: //sar
                                FireSemi((int)(20 / sensitivity), 8, 170, true);
                                break;
                            case 9: //ak
                                Fire(RecoilTables.akTable, bulletCount, 4, 130);
                                break;
                            case 10: //m39
                                FireSemi((int)(18 / sensitivity), 8, 200, true);
                                break;
                            case 11: //lr
                                Fire(RecoilTables.lrTable, bulletCount, 4, 117);
                                break;
                            case 12: //m249
                                FireSemi((int)(16.8 / sensitivity), 8, 117, false);
                                break;
                        }
                    }
                    else //the player is standing
                    {
                        switch (GUI.selectedWeapon)
                        {
                            case 0: //nailgun
                                FireSemi((int)(28 / sensitivity), 8, 145, true);
                                break;
                            case 1: //rev
                                FireSemi((int)(25 / sensitivity), 8, 170, true);
                                break;
                            case 2: //python
                                FireSemi((int)(75 / sensitivity), 8, 145, true);
                                break;
                            case 3: //p250
                                FireSemi((int)(38 / sensitivity), 8, 145, true);
                                break;
                            case 4: //m92
                                FireSemi((int)(34 / sensitivity), 8, 145, true);
                                break;
                            case 5: //custom
                                Fire(RecoilTables.customTable, bulletCount, 4, 105);
                                break;
                            case 6: //thompson
                                Fire(RecoilTables.thompsonTable, bulletCount, 4, 128);
                                break;
                            case 7: //mp5
                                Fire(RecoilTables.mp5Table, bulletCount, 4, 105);
                                break;
                            case 8: //sar
                                FireSemi((int)(40 / sensitivity), 8, 170, true);
                                break;
                            case 9: //ak
                                Fire(RecoilTables.akTable, bulletCount, 4, 130);
                                break;
                            case 10: //m39
                                FireSemi((int)(36 / sensitivity), 8, 200, true);
                                break;
                            case 11: //lr
                                Fire(RecoilTables.lrTable, bulletCount, 4, 117);
                                break;
                            case 12: //m249
                                FireSemi((int)(35 / sensitivity), 8, 117, false);
                                break;
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }

        static bool IsTableSafe(double[][] table, int bulletCount)
        {
            return table.Length > bulletCount;
        }

        static void FireSemi(int pullDown, int movementsPerShot, int msBetweenShots, bool shouldPress)
        {
            if (shouldPress)
            {
                InputHandler.KeyPress(triggerKey);
            }
            for (int i = 0; i < movementsPerShot; ++i)
            {
                InputHandler.RelativeMove(0, pullDown / movementsPerShot);
                Thread.Sleep(msBetweenShots / movementsPerShot);
            }
        }

        static void Fire(double[][] table, int bulletCount, int movementsPerShot, int msBetweenShots)
        {
            if (IsTableSafe(table, bulletCount))
            {
                double multiplier = -0.03 * (sensitivity * 3.0) * (fov / 100.0);
                double stepX;
                double stepY;
                if (bulletCount - 1 >= 0)
                {
                    stepX = table[bulletCount][0] - table[bulletCount - 1][0];
                    stepY = table[bulletCount][1] - table[bulletCount - 1][1];
                }
                else
                {
                    stepX = table[bulletCount][0];
                    stepY = table[bulletCount][1];
                }
                stepX *= recoilMultiplier;
                stepY *= recoilMultiplier;
                stepX /= movementsPerShot;
                stepY /= movementsPerShot;
                stepX /= multiplier;
                stepY /= multiplier;
                for (int i = 0; i < movementsPerShot; ++i)
                {
                    InputHandler.RelativeMove((int)stepX, (int)stepY);
                    Thread.Sleep((int)(fireRateMultiplier *  (msBetweenShots / movementsPerShot)));
                }
            }
        }
    }
}
