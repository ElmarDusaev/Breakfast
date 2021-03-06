﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    /// <summary>
    /// Статусы для продукции
    ///     Active - продукция активна, есть в наличии
    ///     Inactive - продукции нет в наличии
    /// </summary>
    public enum ProductStatus
    {
        [Description("Отключен")]
        Inactive,
        [Description("Активен")]
        Active
    }

    /// <summary>
    /// Статусы заказа
    ///     Requested - новый созданный заказ
    ///     Inprogress - заказ в наборке
    ///     Done - заказ набран
    ///     Delivery - Заказ в пути, доставка до клиента
    ///     Rejected - Заказ отменен 
    /// </summary>
    public enum OrderHdrStatus
    {

        [Description("Новый")] 
        Requested, 
        [Description("В наборке")]
        InProgress, 
        [Description("Набран")]
        Done, 
        [Description("В пути")]
        Delivery, 
        [Description("Отказ")]
        Rejected,
        [Description("Выполнен")]
        Closed
    }

    /// <summary>
    /// Статусы продукции для наборшика внутри заказа
    ///     Wait - ожидание наборки
    ///     RejectedByOperator - Отменен оператором
    ///     Done - Продукция набрана
    /// </summary>
    public enum OrderDtlStatus
    {
        [Description("Отменен")]
        Wait,
        [Description("Набран")]
        Done,
        [Description("Отменен опертором")]
        RejectedByOperator
    }


    enum Months
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }

}
