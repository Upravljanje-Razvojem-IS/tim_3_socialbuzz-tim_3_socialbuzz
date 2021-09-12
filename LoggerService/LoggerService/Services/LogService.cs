using AutoMapper;
using LoggerService.Dtos;
using LoggerService.Exceptions;
using LoggerService.Model;
using LoggerService.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerService.Services
{
    public class LogService : ILogService
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogRepository _logRepo;
        private readonly IMapper _mapper;

        public LogService(IUserRepository userRepo, ILogRepository logRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _logRepo = logRepo;
            _mapper = mapper;
        }

        public IList<LogDto> GetLogs(LogParamsDto logParams)
        {
            var query = _logRepo.GetBasicQuery();

            if (logParams.UserId != Guid.Empty)
            {
                query = query.Where(l => l.User.Id.Equals(logParams.UserId));
            }

            if (logParams.From != DateTime.MinValue)
            {
                query = query.Where(l => l.Timestamp >= logParams.From);
            }

            if (logParams.To != DateTime.MinValue)
            {
                query = query.Where(l => l.Timestamp <= logParams.To);
            }

            query = query.Include(l => l.User);

            return _mapper.Map<IList<LogDto>>(_logRepo.GetLogsForQuery(query));
        }

        public LogDto SaveLog(SaveLogDto logDto)
        {
            var user = _userRepo.GetById(logDto.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(logDto.UserId);
            }

            var log = _mapper.Map<Log>(logDto);
            log.User = user;
            log.Timestamp = DateTime.Now;

            return _mapper.Map<LogDto>(_logRepo.SaveLog(log));
        }
    }
}
