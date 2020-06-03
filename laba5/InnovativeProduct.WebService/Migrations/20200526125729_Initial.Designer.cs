﻿// <auto-generated />
using InnovativeProduct.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InnovativeProduct.WebService.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20200526125729_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("InnovativeProduct.DomainObjects.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExpectedEffects")
                        .HasColumnType("TEXT");

                    b.Property<string>("Indicators")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Specifications")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tasks")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ExpectedEffects = "Экономический эффект: внедрение 1 комплекта системы позволяет в среднем получить до 6 млн. руб. в месяц бюджет города в виде оплачиваемых нарушителями штрафов.",
                            Indicators = "Соответствие постановлению Правительства г. Москвы от 11.01.2011 № 1 -ПП «О создании интеллектуальной транспортной системы города Москвы» в части реализации пункта №6 «Система фотовидеофиксации нарушений ПДЦ»Внедрение системы позволит осуществлять автоматическую фотовидеофиксацию нарушений правил дорожного движения, обеспечить повышение пропускной способности дорожной сети, уменьшение числа несчастных случаев и т.д. ",
                            Name = "Система фотовидеофиксации нарушений правил проезда регулируемых перекрёстков и железнодорожных переездов автоматическая (степень защиты - не ниже IP54, типы распознаваемых ГРЗ - все типы однострочных государственных регистрационных знаков)",
                            Specifications = "Исполнение - стационарное; Степень защиты - не ниже IP54; Типы распознаваемых ГРЗ - все типы однострочных государственных регистрационных знаков, соответствующих ГОСТ Р 50557-93 исключая примечания и ОСТ 78-1-73; Точность распознавания ГРЗ - более 97%. ",
                            Tasks = "Система предназначена для фотовидеофиксации ПДД: проезд на запрещающий сигнал светофора (КоАП РФ 12.12.ч1); невыполнение требования ПДЦ об остановке перед стоп линией (КоАП РФ 12.12.42); проезд ж/д путей на запрещающий сигнал светофора (КоАП РФ 12.10.41); движение транспортных средств по полосе для маршрутных транспортных средств (КОАП 12.17. ч. 1.1 и 1.2); движение по обочинам (КОАП 12.15. ч. 1)."
                        },
                        new
                        {
                            Id = 2L,
                            ExpectedEffects = "Экономический эффект: снижение затрат на эксплуатацию металлических изделий городской инфраструктуры и ЖКХ в 2-3 раза. Социальный эффект: повышение безопасности за счет снижения аварийности объектов промышленности и ЖКХ, автотранспорта, строительных конструкций; улучшение качества жизни за счет улучшения внешнего вида объектов инфраструктуры и транспорта, снижения аварий в ЖКХ.",
                            Indicators = "Не токсичное покрытие, без запаха, допустимость контакта с нефтепродуктами, пресной, морской и питьевой водой. Пожаро-зрывобезопасность: не образует искры, не распространяет пламя по поверхности, температура вспышки отсутствует. Технологичность: покрытие наносится как обычная краска, с использованием стандартного окрасочного оборудования. Ремонтопригодность. Высокая твердость и износоустойчивость. Исключительная стойкость к действию солнечной радиации.",
                            Name = " Покрытие антикоррозионное цинксиликатное на основе высокомодульного модифицированного жидкого стекла (твердость – 800 HRB и более, адгезия 1 балл, термостойкость 450С)",
                            Specifications = "Покрытие: толщина одного сухого слоя: 75-150 мкм; твердость – 800 HRB и более; адгезия: 1 балл; термостойкость: 450 °С, негорючесть, контакт с питьевой водой; время высыхания при температуре 20 °С и влажности воздуха 65%: не более 15 мин, стойкость к воде через 3-4 часа; компоненты: связующее: силикатный модуль не менее 5,0, наполнитель – цинк не менее 98%, композиция: плотность: 3,3 г/см3±10%; массовая доля нелетучих веществ: 78-82%, ЛОС не более 1%; температурный диапазон эксплуатации: от -60°С до +450°С; срока службы более 20 лет; срока высыхания слоя на отлип 5-15 минут, стойкость к воде через 3-4 час; гарантийный срок хранения в закрытой таре: компонентов не менее 18 месяцев, композиции не менее 24 ч.",
                            Tasks = "Защита от коррозии металлических конструкций эксплуатируемых в атмосферных условиях всех климатических зон для всех категорий размещения изделий: в морской и пресной воде, в условиях погружения в сырые и светлые нефтепродукты, в контакте с питьевой водой, в качестве самостоятельного покрытия или в качестве грунтовки в комплексных системах покрытий "
                        },
                        new
                        {
                            Id = 3L,
                            ExpectedEffects = "Экономический эффект: отечественные аналоги оборудования дешевле импортных не менее чем на 50%. Социальный эффект: снижение числа смертности среди больных с сердечной недостаточностью.",
                            Indicators = "Эффективное лечение заболеваний сердечно-сосудистой системы в тяжелых формах; решение вопроса дефицита донорских органов и носимых систем искусственного левого желудочка сердца; имеются аналоги отечественного производства; снижение числа смертности среди больных с сердечной недостаточностью",
                            Name = "Аппарат вспомогательного кровообращения носимый АВК-Н (искусственный левый желудочек сердца. Вес имплантируемых компонент - 250 г, время работ в автономном режиме – 14 час)",
                            Specifications = "Диапазон регулирования потока крови - от 3 до 7 л/мин.; вес имплантируемых компонент - 250 г; время работ в автономном режиме – 14 час; потребляемая мощность – 12 Вт",
                            Tasks = "Замена транспортной функции левого желудочка сердца у больных с тяжёлыми формами сердечной недостаточности. Применяется в сердечной хирургии, медицине катастроф и реанимации"
                        },
                        new
                        {
                            Id = 4L,
                            ExpectedEffects = "Социальный эффект: повышение качества образования",
                            Indicators = "Обеспечивает развитие научно-технического творчества, углубленного изучения естественнонаучных дисциплин, расширяет кругозор и обеспечивает заинтересованность учащегося",
                            Name = "Комплекс лабораторный для учебной практической и проектной деятельности по естествознанию (ЛКЕ)",
                            Specifications = "Комплекс представляет собой автоматизированное рабочее место для межпредметных исследований по естественнонаучным дисциплинам. Комплекс включает более 155 наименований лабораторного оборудования, приборов, наборов, приспособлений, узлов и деталей, а также стеклянную, полимерную и керамическую посуду, инструменты и принадлежности, в том числе: ноутбук, комплект цифровых датчиков, цифровой микроскоп с набором микропрепаратов, электронные приборы (весы, термометр, дозиметр, мультиметр, ампервольтметр), источники электропитания 220/42В, 42/4.5В, аккумуляторный источник питания с зарядным устройством, калориметр, магнитная мешалка, набор по электрохимии, штативы с приспособлениями из нержавеющей стали и др. Состав: лабораторная посуда; штативы, наборы по механике; средства измерения; наборы по электродинамике, оптике и квантовым явлениям; источники питания, электрооборудование; микропрепараты, цифровая лаборатория.",
                            Tasks = "Создание материально-технической базы для проведения проектной и исследовательской деятельности"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
