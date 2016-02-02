﻿namespace Sitecore.Feature.Maps.Controllers
{
  using System;
  using System.Linq;
  using System.Web.Mvc;
  using Data;
  using Models;
  using Repositories;

  public class MapsController : Mvc.Controllers.SitecoreController
  {
    private readonly IMapRepository mapRepository;

    public MapsController() : this(new MapRepository())
    {
    }

    public MapsController(IMapRepository mapRepository)
    {
      this.mapRepository = mapRepository;
    }     

    [HttpPost]
    public JsonResult GetMapPoints(Guid itemId)
    {
      var item = Context.Database.GetItem(new ID(itemId));
      var points = mapRepository.GetAll(item).Select(i=> new MapPoint(i));

      return Json(points);
    }
  }
}