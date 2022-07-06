using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.XWPF.UserModel;
using System.IO;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.BI.Interfaces;

namespace Insomnia.Agreemod.BI.Services
{
    public class WordService : IWord
    {
        public WordService()
        {

        }

        public void CreateDocument(List<TimetableDto> timetables)
        {
            XWPFDocument doc = new XWPFDocument();

            foreach (var t in timetables.GroupBy(x => x.Location).ToList())
            {
                XWPFParagraph para = doc.CreateParagraph();
                XWPFRun r0 = para.CreateRun();
                r0.SetText(t.Key);
                r0.AddCarriageReturn();
                r0.FontSize = 14;
                r0.IsBold = true;

                foreach (var day in t.GroupBy(x => x.Day).ToList())
                {

                    XWPFParagraph d = doc.CreateParagraph();
                    XWPFRun r3 = d.CreateRun();
                    r3.SetText(day.Key);
                    r3.AddCarriageReturn();
                    r3.IsItalic = true;
                    r3.FontSize = 11;
                    var countAudiences = day.SelectMany(x => x.Audiences).Count();
                    switch (countAudiences)
                    {
                        case 1:
                            foreach (var element in day.SelectMany(x => x.Audiences.SelectMany(y => y.Elements)).OrderBy(x => x.Time).ToList())
                            {
                                if (!String.IsNullOrEmpty(element.Time))
                                {
                                    XWPFParagraph el = doc.CreateParagraph();
                                    XWPFRun r1 = el.CreateRun();

                                    r1.SetText(element.Time);
                                    r1.FontSize = 10;
                                }
                                if (!String.IsNullOrEmpty(element.Name))
                                {
                                    XWPFParagraph el = doc.CreateParagraph();
                                    XWPFRun r1 = el.CreateRun();

                                    r1.AppendText(element.Name);
                                    r1.FontSize = 10;
                                    r1.IsBold = true;
                                }
                                if (!String.IsNullOrEmpty(element.Description))
                                {
                                    XWPFParagraph el = doc.CreateParagraph();
                                    XWPFRun r1 = el.CreateRun();

                                    r1.AppendText(element.Description);

                                    r1.AddCarriageReturn();
                                    r1.IsItalic = true;
                                    r1.FontSize = 10;
                                }
                                if (!String.IsNullOrEmpty(element.Speaker))
                                {
                                    XWPFParagraph el = doc.CreateParagraph();
                                    XWPFRun r1 = el.CreateRun();

                                    r1.AppendText(element.Speaker);
                                    r1.IsBold = true;

                                    r1.FontSize = 10;
                                }
                                if (!String.IsNullOrEmpty(element.SpeakerDescription))
                                {
                                    XWPFParagraph el = doc.CreateParagraph();
                                    XWPFRun r1 = el.CreateRun();

                                    r1.AppendText(element.SpeakerDescription);
                                    r1.IsItalic = true;

                                    r1.FontSize = 10;
                                }
                            }
                            break;
                        case 2:
                            foreach (var audience in day.SelectMany(x => x.Audiences).OrderBy(x => x.Number).ToList())
                            {
                                XWPFParagraph auditory = doc.CreateParagraph();
                                XWPFRun r5 = auditory.CreateRun();
                                r5.SetText($"Аудитория {audience.Number}");
                                r5.AddCarriageReturn();
                                r5.IsBold = true;

                                foreach (var element in audience.Elements.OrderBy(x => x.Time).ToList())
                                {
                                    if (!String.IsNullOrEmpty(element.Time))
                                    {
                                        XWPFParagraph el = doc.CreateParagraph();
                                        XWPFRun r1 = el.CreateRun();

                                        r1.SetText(element.Time);
                                        r1.FontSize = 10;
                                    }
                                    if (!String.IsNullOrEmpty(element.Name))
                                    {
                                        XWPFParagraph el = doc.CreateParagraph();
                                        XWPFRun r1 = el.CreateRun();

                                        r1.AppendText(element.Name);
                                        r1.FontSize = 10;
                                        r1.IsBold = true;
                                    }
                                    if (!String.IsNullOrEmpty(element.Description))
                                    {
                                        XWPFParagraph el = doc.CreateParagraph();
                                        XWPFRun r1 = el.CreateRun();

                                        r1.AppendText(element.Description);

                                        r1.AddCarriageReturn();
                                        r1.IsItalic = true;
                                        r1.FontSize = 10;
                                    }
                                    if (!String.IsNullOrEmpty(element.Speaker))
                                    {
                                        XWPFParagraph el = doc.CreateParagraph();
                                        XWPFRun r1 = el.CreateRun();

                                        r1.AppendText(element.Speaker);
                                        r1.IsBold = true;

                                        r1.FontSize = 10;
                                    }
                                    if (!String.IsNullOrEmpty(element.SpeakerDescription))
                                    {
                                        XWPFParagraph el = doc.CreateParagraph();
                                        XWPFRun r1 = el.CreateRun();

                                        r1.AppendText(element.SpeakerDescription);
                                        r1.IsItalic = true;

                                        r1.FontSize = 10;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }


                }

            }

            FileStream out1 = new FileStream("locations.docx", FileMode.Create);
            doc.Write(out1);
            out1.Close();
        }
    }
}
