using System;
using System.Net.Mail;

namespace AkkaDddSandbox.App
{
    public class EntityService
    {
        private readonly IEntityRepository _repository;
        private readonly IEmailService _emailService;

        public EntityService(IEntityRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public void RestoreEntity(int entityId)
        {
            var entity = _repository.GetById(entityId);
            entity.Restore();

            _repository.SaveChangesTo(entity);
            _emailService.Send("nobody@mail.com", "Entity restored", $"{entity} was restored.");
        }

        public void RetireEntity(int entityId)
        {
            var entity = _repository.GetById(entityId);
            entity.Restore();

            _repository.SaveChangesTo(entity);
            _emailService.Send("nobody@mail.com", "Entity restored", $"{entity} has been retired.");
        }
    }

    public interface IEntity
    {
        string State { get; }
        void Restore();
        void Retire();
    }

    public class Entity : IEntity
    {
        public Entity(string state)
        {
            State = state;
        }

        public string State { get; private set; }
        public void Restore()
        {
            if (State != "Retired")
                throw new Exception("The entity is not retired!");

            State = "Not retired";
            // do other restore logic
        }

        public void Retire()
        {
            if (State == "Retired")
                throw new Exception("The entity is already retired!");

            State = "Retired";
            // do other retirement logic
        }
    }

    public interface IEntityRepository
    {
        IEntity GetById(int entityId);
        void SaveChangesTo(IEntity entity);
    }

    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                var message = new MailMessage
                {
                    Subject = subject,
                    Body = body
                };

                message.To.Add(new MailAddress(to));
                client.Send(message);
            }
        }
    }
}
