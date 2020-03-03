import { TestBed } from '@angular/core/testing';

import { AutenticationService } from './Autentication.service';

describe('AutenticationService', () => {
  let service: AutenticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutenticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
