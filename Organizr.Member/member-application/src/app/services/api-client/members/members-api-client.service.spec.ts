import { TestBed } from '@angular/core/testing';

import { MembersApiClientService } from './members-api-client.service';

describe('MembersApiClientService', () => {
  let service: MembersApiClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembersApiClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
