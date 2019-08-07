using Entities;
using GKBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GKWebApi.Controllers
{
    /// <summary>
    /// Labels Contoller for accessing the Notes DataBase.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        // create a refrence of service Interface and initialize it.
        private readonly IKeepNoteService keepNoteService;
        public NotesController(IKeepNoteService noteService)
        {
            keepNoteService = noteService;
        }


        // GET: api/Notes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(keepNoteService.GetAllNotes());
            }
            catch (Exception exp)
            {

                return NotFound(exp.Message);
            }
        }



        // GET: api/Notes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(keepNoteService.GetNotesByID(id));
            }
            catch (Exception exp)
            {
                return NotFound(exp.Message);
                
            }
        }

        // POST: api/Notes
        [HttpPost]
        public IActionResult Post([FromBody] Notes notes)
        {
            try
            { 

                keepNoteService.CreateNote(notes);
                return Created("api/Notes",notes);
            }
            catch (Exception exp)
            {
                return NotFound(exp.Message);
            }
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Notes notes)
        {
            try
            {
                return Ok(keepNoteService.UpdateNote(id , notes));
            }
            catch (Exception exp)
            {
                return NotFound(exp.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(keepNoteService.RemoveNote(id));
            }
            catch (Exception exp)
            {
                return NotFound(exp.Message);
            }
        }


        // Contoller Method For Labels start from here.
        [HttpGet("{id}/label")]
        public IActionResult GetLabelByNoteID(int id)
        {
            try
            {
                return Ok(keepNoteService.GetLabels(id));
            }
            catch (Exception exp)
            {

                return NotFound(exp.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Label label)
        {
            try
            {
                keepNoteService.CreateLabel(id, label);
                return Created("api/note",label);
            }
            catch (Exception exp)
            {

                return NotFound(exp.Message);
            }
        }

        [HttpPut("{lid}/label")]
        public IActionResult Put(int lid, [FromBody] Label label)
        {
            try
            {
                keepNoteService.UpdateLabel(lid, label);
                return Ok();
            }
            catch (Exception exp)
            {
                return NotFound(exp.Message);
            }
        }

        [HttpDelete("{nid}/label/{lid}")]
        public IActionResult Delete(int nid, int lid)
        {
            try
            {
                keepNoteService.RemoveLabel(nid, lid);
                return Ok();
            }
            catch (Exception exp)
            {

                return NotFound(exp.Message);
            }
        }
    }
}
